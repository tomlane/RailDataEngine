namespace RailDataEngine.Domain.Services.ScheduleMessageConversionService
{
    public interface IScheduleMessageConversionService
    {
        ScheduleMessageConversionResponse ConvertScheduleMessages(ScheduleMessageConversionRequest request);
    }
}
