using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity
{
    public class DeserializedJsonScheduleSegment
    {
        [JsonProperty("signalling_id")]
        public string SignallingId { get; set; }

        [JsonProperty("CIF_train_category")]
        public string TrainCategory { get; set; }

        [JsonProperty("CIF_headcode")]
        public string HeadCode { get; set; }

        [JsonProperty("CIF_course_indicator")]
        public string CourseIndicator { get; set; }

        [JsonProperty("CIF_train_service_code")]
        public string TrainServiceCode { get; set; }

        [JsonProperty("CIF_business_sector")]
        public string BusinessSector { get; set; }

        [JsonProperty("CIF_power_type")]
        public string PowerType { get; set; }

        [JsonProperty("CIF_timing_load")]
        public string TimingLoad { get; set; }

        [JsonProperty("CIF_speed")]
        public string Speed { get; set; }

        [JsonProperty("CIF_operating_characteristics")]
        public string OperatingCharateristics { get; set; }

        [JsonProperty("CIF_train_class")]
        public string TrainClass { get; set; }

        [JsonProperty("CIF_sleepers")]
        public string Sleepers { get; set; }

        [JsonProperty("CIF_reservations")]
        public string Reservations { get; set; }

        [JsonProperty("CIF_connection_indicator")]
        public string ConnectionIndicator { get; set; }

        [JsonProperty("CIF_catering_code")]
        public string CateringCode { get; set; }

        [JsonProperty("CIF_service_branding")]
        public string ServiceBranding { get; set; }

        [JsonProperty("schedule_location")]
        public DeserilaizedJsonLocation[] ScheduleLocation { get; set; }
    }
}