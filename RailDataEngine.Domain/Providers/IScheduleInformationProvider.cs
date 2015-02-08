using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Entity.TrainMovements;

namespace RailDataEngine.Domain.Providers
{
    public interface IScheduleInformationProvider
    {
        Category? GetAssociationCategory(string associationCategory);
        TrainCallMode? GetTrainCallMode(string trainCallMode);
        ScheduleType? GetScheduleType(string scheduleType);
        ScheduleSource? GetScheduleSource(string scheduleSource);
        StpIndicator? GetStpIndicator(string stpIndicator);
        TransactionType? GetTransactionType(string transactionType);
        DateIndicator? GetDateIndicator(string dateIndicator);
        LocationType? GetLocationType(string locationType);
    }
}
