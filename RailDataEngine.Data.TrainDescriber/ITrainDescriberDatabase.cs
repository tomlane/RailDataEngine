namespace RailDataEngine.Data.TrainDescriber
{
    public interface ITrainDescriberDatabase
    {
        ITrainDescriberContext DbContext { get; set; }
        ITrainDescriberContext BuildContext();
    }
}
