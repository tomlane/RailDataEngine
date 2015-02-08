using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity;

namespace RailDataEngine.Services.MessageConversion.Schedule
{
    public class JsonScheduleMessageDeserializationService : IScheduleMessageDeserializationService
    {
        public ScheduleMessageDeserializationResponse DeserializeScheduleMessages(ScheduleMessageDeserializationRequest request)
        {
            if (request == null || request.MessageToDeserialize == null)
                throw new ArgumentNullException("request");

            var response = new ScheduleMessageDeserializationResponse
            {
                Associations = new List<DeserializedJsonAssociation>(),
                Headers = new List<DeserializedJsonScheduleHeader>(),
                Records = new List<DeserializedJsonScheduleRecord>(),
                Tiplocs = new List<DeserializedJsonTiploc>()
            };

            foreach (var line in request.MessageToDeserialize)
            {
                JObject jsonObject = JObject.Parse(line);

                IList<string> keys = jsonObject.Properties().Select(p => p.Name).ToList();

                string messageType = keys.First();

                switch (messageType)
                {
                    case "JsonTimetableV1":
                        response.Headers.Add(DeserializeHeader(jsonObject.ToString()));
                        break;
                    case "JsonAssociationV1":
                        response.Associations.Add(DeserializeAssociation(jsonObject.ToString()));
                        break;
                    case "TiplocV1":
                        response.Tiplocs.Add(DeserializeTiploc(jsonObject.ToString()));
                        break;
                    case "JsonScheduleV1":
                        response.Records.Add(DeserializeScheduleRecord(jsonObject.ToString()));
                        break;
                }
            }

            return response;
        }

        private DeserializedJsonScheduleHeader DeserializeHeader(string header)
        {
            return string.IsNullOrWhiteSpace(header) ? null : JsonConvert.DeserializeObject<DeserializedJsonScheduleHeader>(header);
        }

        private DeserializedJsonAssociation DeserializeAssociation(string association)
        {
            return string.IsNullOrWhiteSpace(association) ? null : JsonConvert.DeserializeObject<DeserializedJsonAssociation>(association);
        }

        private DeserializedJsonTiploc DeserializeTiploc(string tiploc)
        {
            return string.IsNullOrWhiteSpace(tiploc) ? null : JsonConvert.DeserializeObject<DeserializedJsonTiploc>(tiploc);
        }

        private DeserializedJsonScheduleRecord DeserializeScheduleRecord(string record)
        {
            return string.IsNullOrWhiteSpace(record) ? null : JsonConvert.DeserializeObject<DeserializedJsonScheduleRecord>(record);
        }
    }
}
