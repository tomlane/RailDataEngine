using System.Collections.Generic;
using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Services.ScheduleMessageConversionService
{
    public class ScheduleMessageConversionResponse
    {
        public List<Association> Associations { get; set; }
        public List<Header> Headers { get; set; }
        public List<Record> Records { get; set; }
        public List<Tiploc> Tiplocs { get; set; }
    }
}