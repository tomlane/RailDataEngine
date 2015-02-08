using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity
{
    public class DeserilaizedJsonLocation
    {
        [JsonProperty("location_type")]
        public string LocationType { get; set; }

        [JsonProperty("record_identity")]
        public string RecordIdentity { get; set; }

        [JsonProperty("tiploc_code")]
        public string TiplocCode { get; set; }

        [JsonProperty("tiploc_instance")]
        public string TiplocInstance { get; set; }

        [JsonProperty("arrival")]
        public string Arrival { get; set; }

        [JsonProperty("departure")]
        public string Departure { get; set; }

        [JsonProperty("pass")]
        public string Pass { get; set; }

        [JsonProperty("public_arrival")]
        public string PublicArrival { get; set; }

        [JsonProperty("public_departure")]
        public string PublicDeparture { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("engineering_allowance")]
        public string EngineeringAllowance { get; set; }

        [JsonProperty("pathing_allowance")]
        public string PathingAllowance { get; set; }

        [JsonProperty("performance_allowance")]
        public string PerformanceAllowance { get; set; }
    }
}