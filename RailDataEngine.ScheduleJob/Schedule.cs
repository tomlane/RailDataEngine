using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Azure.WebJobs;
using Microsoft.Practices.Unity;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using RailDataEngine.Core;
using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Exception;
using RailDataEngine.Domain.Gateway.Schedule;
using RailDataEngine.Domain.Services.ScheduleMessageConversionService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Domain.Services.ScheduleMessageStorageService;

namespace RailDataEngine.ScheduleJob
{
    public class Schedule
    {
        private static IUnityContainer _container;

        [NoAutomaticTrigger]
        public static void Fetch()
        {
            _container = ContainerBuilder.Build();

            var scheduleContents = GetScheduleFile();

            //SaveToAzureStorage(scheduleContents);
            ApplyScheduleUpdate(scheduleContents);
        }

        private static void ApplyScheduleUpdate(string scheduleContents)
        {
            if (string.IsNullOrWhiteSpace(scheduleContents))
                throw new ArgumentNullException("scheduleContents");

            var messageDeserializationService = _container.Resolve<IScheduleMessageDeserializationService>();
            var messageConversionService = _container.Resolve<IScheduleMessageConversionService>();
            var scheduleStorageService = _container.Resolve<IScheduleMessageStorageService>();
            var headerGateway = _container.Resolve<IScheduleStorageGateway<Header>>();

            var scheduleMessages = scheduleContents.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None).ToList();

            var deserializedMessages =
                messageDeserializationService.DeserializeScheduleMessages(new ScheduleMessageDeserializationRequest
                {
                    MessagesToDeserialize = scheduleMessages
                });

            var convertedMessages =
                messageConversionService.ConvertScheduleMessages(new ScheduleMessageConversionRequest
                {
                    Associations = deserializedMessages.Associations,
                    Headers = deserializedMessages.Headers,
                    Records = deserializedMessages.Records,
                    Tiplocs = deserializedMessages.Tiplocs
                });

            int currentVersion = headerGateway.GetScheduleVersion();
            int updateVersion = int.Parse(convertedMessages.Headers.First().MetaData.Sequence);

            if (currentVersion >= updateVersion)
                throw new InvalidScheduleUpdateException(currentVersion, updateVersion, scheduleContents);

            scheduleStorageService.SaveScheduleMessages(new SaveScheduleMessagesRequest
            {
                Associations = convertedMessages.Associations,
                Headers = convertedMessages.Headers,
                Records = convertedMessages.Records,
                Tiplocs = convertedMessages.Tiplocs
            });
        }

        private static void SaveToAzureStorage(string fileContents)
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["ScheduleStorageAccount"].ConnectionString);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container =
                blobClient.GetContainerReference(ConfigurationManager.AppSettings["ScheduleContainer"]);

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(GetBlobName());
            
            blockBlob.UploadText(fileContents);
        }

        private static string GetBlobName()
        {
            var currentDate = DateTime.Now.ToString("ddMMyy");

            return string.Format("fgw-schedule-update-{0}.json", currentDate);
        }
        
        private static string GetScheduleFile()
        {
            var request = (HttpWebRequest) WebRequest.Create(GetScheduleUri());

            string authInfo = string.Format("{0}:{1}", ConfigurationManager.AppSettings["Username"],
                ConfigurationManager.AppSettings["Password"]);
                
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;

            var response = request.GetResponse();

            using (var gzipStream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
            {
                const int size = 4096;
                byte[] buffer = new byte[size];
                using (MemoryStream memory = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = gzipStream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memory.Write(buffer, 0, count);
                        }
                    }
                    while (count > 0);
                    var array = memory.ToArray();

                    return Encoding.Default.GetString(array);
                }
            }
        }

        private static string GetScheduleUri()
        {
            string currentTime = DateTime.Now.DayOfWeek.ToString();

            switch (currentTime)
            {
                case "Monday":
                    return ScheduleUrls.SundaySchedule;
                case "Tuesday":
                    return ScheduleUrls.MondaySchedule;
                case "Wednesday":
                    return ScheduleUrls.TuesdaySchedule;
                case "Thursday":
                    return ScheduleUrls.WednesdaySchedule;
                case "Friday":
                    return ScheduleUrls.ThursdaySchedule;
                case "Saturday":
                    return ScheduleUrls.FridaySchedule;
                case "Sunday":
                    return ScheduleUrls.SaturdaySchedule;
            }

            return null;
        }
    }
}
