using System;
using System.Configuration;
using System.Linq;
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

            var scheduleContents = ScheduleHelper.GetScheduleFile();

            SaveToAzureStorage(scheduleContents);
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

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(ScheduleHelper.GetBlobName());
            
            blockBlob.UploadText(fileContents);
        }
    }
}
