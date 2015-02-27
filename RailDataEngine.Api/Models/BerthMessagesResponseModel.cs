using System.Collections.Generic;
using RailDataEngine.Domain.Entity.TrainDescriber.Berth;

namespace RailDataEngine.Api.Models
{
    public class BerthMessagesResponseModel
    {
        public List<BerthMessage> BerthMessages { get; set; }
    }
}