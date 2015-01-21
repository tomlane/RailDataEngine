namespace RailDataEngine.Domain.Entity.Schedule
{
    public class Tiploc
    {
        public TransactionType? TransactionType { get; set; }
        public string TiplocCode { get; set; }
        public string Nalco { get; set; }
        public string Stanox { get; set; }
        public string CrsCode { get; set; }
        public string Description { get; set; }
        public string TpsDescription { get; set; }
    }
}
