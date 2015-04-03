using Newtonsoft.Json;

namespace RailDataEngine.Domain.Deserializers.Schedule.Entity
{
    public class DeserializedJsonNewScheduleSegment
    {
        [JsonProperty("traction_class")]
        public string TractionClass { get; set; }

        [JsonProperty("uic_code")]
        public string UicCode { get; set; }
    }
}