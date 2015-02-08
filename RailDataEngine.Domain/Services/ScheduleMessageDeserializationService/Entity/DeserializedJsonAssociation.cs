using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity
{
    public class DeserializedJsonAssociation
    {
        [JsonProperty("JsonAssociationV1")]
        public DeserializedJsonAssociationBody Association { get; set; }
    }

    public class DeserializedJsonAssociationBody
    {
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("main_train_uid")]
        public string TrainUid { get; set; }

        [JsonProperty("assoc_train_uid")]
        public string AssociationTrainUid { get; set; }

        [JsonProperty("assoc_start_date")]
        public string StartDate { get; set; }

        [JsonProperty("assoc_end_date")]
        public string EndDate { get; set; }

        [JsonProperty("assoc_days")]
        public string RunningDays { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("date_indicator")]
        public string DateIndicator { get; set; }

        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("base_location_suffix")]
        public string LocationSuffix { get; set; }

        [JsonProperty("assoc_location_suffix")]
        public string AssociationSuffix { get; set; }

        [JsonProperty("diagram_type")]
        public string DiagramType { get; set; }

        [JsonProperty("CIF_stp_indicator")]
        public string StpIndicator { get; set; }
    }
}
