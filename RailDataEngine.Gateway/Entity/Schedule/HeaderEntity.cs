﻿using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Gateway.Domain;

namespace RailDataEngine.Gateway.Entity.Schedule
{
    public class HeaderEntity : Header, IIdentifyable
    {
        public int Id { get; set; }
    }
}
