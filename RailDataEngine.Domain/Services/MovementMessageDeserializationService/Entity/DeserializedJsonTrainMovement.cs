using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity
{
    public class DeserializedJsonTrainMovement
    {
        [JsonProperty("header")]
        public DeserializedJsonMovementHeader Header { get; set; }

        [JsonProperty("body")]
        public DeserializedJsonMovementBody Body { get; set; }
    }

    public class DeserializedJsonMovementHeader
    {
        [JsonProperty("source_dev_id")]
        public string SourceDevId { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("original_data_source")]
        public string OriginalDataSource { get; set; }

        [JsonProperty("msg_queue_timestamp")]
        public string MessageTimestamp { get; set; }

        [JsonProperty("source_system_id")]
        public string SourceSystemId { get; set; }
    }

    public class DeserializedJsonMovementBody
    {
        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("gbtt_timestamp")]
        public string GbttTimestamp { get; set; }

        [JsonProperty("original_loc_stanox")]
        public string OriginalLocationStanox { get; set; }

        [JsonProperty("planned_timestamp")]
        public string PlannedTimestamp { get; set; }

        [JsonProperty("timetable_variation")]
        public string TimetableVariation { get; set; }

        [JsonProperty("original_loc_timestamp")]
        public string OriginalLocationTimestamp { get; set; }

        [JsonProperty("current_train_id")]
        public string CurrentTrainId { get; set; }

        [JsonProperty("delay_monitoring_point")]
        public string DelayMonitoringPoint { get; set; }

        [JsonProperty("next_report_run_time")]
        public string NextReportRunTime { get; set; }

        [JsonProperty("reporting_stanox")]
        public string ReportingStanox { get; set; }

        [JsonProperty("actual_timestamp")]
        public string ActualTimestamp { get; set; }

        [JsonProperty("correction_ind")]
        public string Correction { get; set; }

        [JsonProperty("event_source")]
        public string EventSource { get; set; }

        [JsonProperty("train_file_address")]
        public string TrainFileAddress { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("divison_code")]
        public string DivisionCode { get; set; }

        [JsonProperty("train_terminated")]
        public string TrainTerminated { get; set; }

        [JsonProperty("train_id")]
        public string TrainId { get; set; }

        [JsonProperty("offroute_ind")]
        public string OffRoute { get; set; }

        [JsonProperty("variation_status")]
        public string VariationStatus { get; set; }

        [JsonProperty("train_service_code")]
        public string TrainServiceCode { get; set; }

        [JsonProperty("toc_id")]
        public string TocId { get; set; }

        [JsonProperty("loc_stanox")]
        public string LocationStanox { get; set; }

        [JsonProperty("auto_expected")]
        public string AutoExpected { get; set; }

        [JsonProperty("direction_ind")]
        public string Direction { get; set; }

        [JsonProperty("route")]
        public string Route { get; set; }

        [JsonProperty("planned_event_type")]
        public string PlannedEventType { get; set; }

        [JsonProperty("next_report_stanox")]
        public string NextReportStanox { get; set; }

        [JsonProperty("line_ind")]
        public string Line { get; set; }
    }
}
