namespace RailDataEngine.Domain.Services.ScheduleMessageDeserializationService
{
    public interface IScheduleMessageDeserializationService
    {
        ScheduleMessageDeserializationResponse DeserializeScheduleMessages(ScheduleMessageDeserializationRequest request);
    }
}
