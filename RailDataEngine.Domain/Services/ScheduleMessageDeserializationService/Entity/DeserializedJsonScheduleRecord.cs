using Newtonsoft.Json;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity
{
    public class DeserializedJsonScheduleRecord
    {
        [JsonProperty("JsonScheduleV1")]
        public DeserializedJsonScheduleBody Schedule { get; set; }
    }

    public class DeserializedJsonScheduleBody
    {
        [JsonProperty("CIF_train_uid")]
        public string TrainUid { get; set; }

        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }

        [JsonProperty("schedule_start_date")]
        public string ScheduleStartDate { get; set; }

        [JsonProperty("schedule_end_date")]
        public string ScheduleEndDate { get; set; }

        [JsonProperty("schedule_days_runs")]
        public string RunDays { get; set; }

        [JsonProperty("CIF_bank_holiday_running")]
        public string BankHolidayRunning { get; set; }

        [JsonProperty("train_status")]
        public string TrainStatus { get; set; }

        [JsonProperty("CIF_stp_indicator")]
        public string StpIndicator { get; set; }

        [JsonProperty("atoc_code")]
        public string AtocCode { get; set; }

        [JsonProperty("applicable_timetable")]
        public string ApplicableTimetable { get; set; }
        
        [JsonProperty("new_schedule_segment")]
        public DeserializedJsonNewScheduleSegment NewScheduleSegment { get; set; }
        
        [JsonProperty("schedule_segment")]
        public DeserializedJsonScheduleSegment ScheduleSegment { get; set; }
    }
}
