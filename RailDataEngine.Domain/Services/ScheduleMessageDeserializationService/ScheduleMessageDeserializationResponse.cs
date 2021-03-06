﻿using System.Collections.Generic;
using RailDataEngine.Domain.Services.ScheduleMessageDeserializationService.Entity;

namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService
{
    public class ScheduleMessageDeserializationResponse
    {
        public List<DeserializedJsonAssociation> Associations { get; set; }
        public List<DeserializedJsonScheduleHeader> Headers { get; set; }
        public List<DeserializedJsonScheduleRecord> Records { get; set; }
        public List<DeserializedJsonTiploc> Tiplocs { get; set; }
    }
}