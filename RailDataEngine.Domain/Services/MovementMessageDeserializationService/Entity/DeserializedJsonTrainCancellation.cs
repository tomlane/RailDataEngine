using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.MovementMessageDeserializationService.Entity
{
    public class DeserializedJsonTrainCancellation
    {
        [JsonProperty("header")]
        public DeserializedJsonCancellationHeader Header { get; set; }

        [JsonProperty("body")]
        public DeserializedJsonCancellationBody Body { get; set; }
    }

    public class DeserializedJsonCancellationHeader
    {
        [JsonProperty("source_dev_id")]
        public string SourceDevId { get; set; }

        [JsonProperty("source_system_id")]
        public string SourceSystemId { get; set; }

        [JsonProperty("original_data_source")]
        public string OriginalDataSource { get; set; }
    }

    public class DeserializedJsonCancellationBody
    {
        [JsonProperty("train_file_address")]
        public string TrainFileAddress { get; set; }

        [JsonProperty("train_service_code")]
        public string TrainServiceCode { get; set; }

        [JsonProperty("orig_loc_stanox")]
        public string OriginLocationStanox { get; set; }

        [JsonProperty("toc_id")]
        public string TocId { get; set; }

        [JsonProperty("dep_timestamp")]
        public string DepartureTimestamp { get; set; }

        [JsonProperty("divison_code")]
        public string DivisionCode { get; set; }

        [JsonProperty("loc_stanox")]
        public string LocationStanox { get; set; }

        [JsonProperty("canx_timestamp")]
        public string CancellationTimestamp { get; set; }

        [JsonProperty("canx_type")]
        public string CancellationType { get; set; }

        [JsonProperty("canx_reason_code")]
        public string CancellationReasonCode { get; set; }

        [JsonProperty("train_id")]
        public string TrainId { get; set; }

        [JsonProperty("orig_loc_timestamp")]
        public string OriginLocationTimestamp { get; set; }

    }
}
