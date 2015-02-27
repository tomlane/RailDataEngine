using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Api.Models
{
    public class SignalMessagesResponseModel
    {
        public List<SignalMessage> SignalMessages { get; set; }
    }
}