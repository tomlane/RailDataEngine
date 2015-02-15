namespace RailDataEngine.Domain.Services.ScheduleMessageStorageService
{
    public interface IScheduleMessageStorageService
    {
        void SaveScheduleMessages(SaveScheduleMessagesRequest request);
    }
}
