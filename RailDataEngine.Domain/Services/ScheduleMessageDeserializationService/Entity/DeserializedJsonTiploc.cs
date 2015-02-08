using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity
{
    public class DeserializedJsonTiploc
    {
        [JsonProperty("TiplocV1")]
        public DeserializedTiplocBody Tiploc { get; set; }
    }

    public class DeserializedTiplocBody
    {
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("tiploc_code")]
        public string Code { get; set; }

        [JsonProperty("nalco")]
        public string Nalco { get; set; }

        [JsonProperty("stanox")]
        public string Stanox { get; set; }

        [JsonProperty("crs_code")]
        public string CrsCode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("tps_description")]
        public string TpsDescription { get; set; }
    }
}
