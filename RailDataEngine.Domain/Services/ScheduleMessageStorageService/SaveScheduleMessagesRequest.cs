using System.Collections.Generic;
using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Services.ScheduleMessageStorageService
{
    public class SaveScheduleMessagesRequest
    {
        public List<Association> Associations { get; set; }
        public List<Header> Headers { get; set; }
        public List<Record> Records { get; set; }
        public List<Tiploc> Tiplocs { get; set; }
    }
}