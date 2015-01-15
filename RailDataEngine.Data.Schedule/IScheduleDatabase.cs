namespace RailDataEngine.Data.Schedule
{
    public interface IScheduleDatabase
    {
        IScheduleContext DbContext { get; set; }
        IScheduleContext BuildContext();
    }
}
