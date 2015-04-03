namespace RailDataEngine.Domain.Entities.TrainDescriber.Berth
{
    public class BerthMessage : TrainDescriberEntity
    {
        public BerthMessageType? MessageType { get; set; }
        public string FromBerth { get; set; }
        public string ToBerth { get; set; }
        public string TrainDescription { get; set; }
    }
}
