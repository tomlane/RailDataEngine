using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity
{
    public class DeserializedJsonScheduleHeader
    {
        [JsonProperty("JsonTimetableV1")]
        public ScheduleHeader ScheduleHeader { get; set; }
    }

    public class ScheduleHeader
    {
        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("Sender")]
        public Sender Sender { get; set; }

        [JsonProperty("Metadata")]
        public MetaData MetaData { get; set; }
    }

    public class Sender
    {
        [JsonProperty("organisation")]
        public string Organisation { get; set; }

        [JsonProperty("application")]
        public string Application { get; set; }

        [JsonProperty("component")]
        public string Component { get; set; }
    }

    public class MetaData
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("sequence")]
        public string Sequence { get; set; }
    }
}
