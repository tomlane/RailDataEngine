namespace RailDataEngine.Data.TrainMovements
{
    public interface ITrainMovementDatabase
    {
        ITrainMovementContext DbContext { get; set; }
        ITrainMovementContext BuildContext();
    }
}
