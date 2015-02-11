using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Providers;

namespace RailDataEngine.Services.MessageConversion.Providers
{
    public class ScheduleInformationProvider : IScheduleInformationProvider
    {
        public Category? GetAssociationCategory(string associationType)
        {
            if (string.IsNullOrWhiteSpace(associationType))
                return null;

            switch (associationType)
            {
                case "JJ":
                    return Category.Join;
                case "VV":
                    return Category.Divide;
                default:
                    return Category.Next;
            }
        }

        public TrainCallMode? GetTrainCallMode(string trainCallMode)
        {
            if (string.IsNullOrWhiteSpace(trainCallMode))
                return null;

            switch (trainCallMode)
            {
                case "NORMAL":
                    return TrainCallMode.Normal;
                default:
                    return TrainCallMode.Overnight;
            }
        }

        public ScheduleType? GetScheduleType(string scheduleType)
        {
            if (string.IsNullOrWhiteSpace(scheduleType))
                return null;

            switch (scheduleType)
            {
                case "C":
                    return ScheduleType.Cancellation;
                case "N":
                    return ScheduleType.New;
                case "O":
                    return ScheduleType.Overlay;
                default:
                    return ScheduleType.Permanent;
            }
        }

        public ScheduleSource? GetScheduleSource(string scheduleSource)
        {
            if (string.IsNullOrWhiteSpace(scheduleSource))
                return null;

            switch (scheduleSource)
            {
                case "C":
                    return ScheduleSource.Cif;
                default:
                    return ScheduleSource.Vstp;
            }
        }

        public StpIndicator? GetStpIndicator(string stpIndicator)
        {
            if (string.IsNullOrWhiteSpace(stpIndicator))
                return null;

            switch (stpIndicator)
            {
                case "C":
                    return StpIndicator.Cancellation;
                case "N":
                    return StpIndicator.New;
                case "O":
                    return StpIndicator.Overlay;
                default:
                    return StpIndicator.Permanent;
            }
        }

        public TransactionType? GetTransactionType(string transactionType)
        {
            if (string.IsNullOrWhiteSpace(transactionType))
                return null;

            switch (transactionType)
            {
                case "update":
                    return TransactionType.Update;
                case "delete":
                    return TransactionType.Delete;
                default:
                    return TransactionType.Create;
            }
        }

        public DateIndicator? GetDateIndicator(string dateIndicator)
        {
            if (string.IsNullOrWhiteSpace(dateIndicator))
                return null;

            switch (dateIndicator)
            {
                case "N":
                    return DateIndicator.Overnight;
                case "P":
                    return DateIndicator.PreviousNight;
                default:
                    return DateIndicator.Standard;
            }
        }

        public LocationType? GetLocationType(string locationType)
        {
            if (string.IsNullOrWhiteSpace(locationType))
                return null;

            switch (locationType)
            {
                case "LT":
                    return LocationType.Terminating;
                case "LI":
                    return LocationType.Intermediate;
                default:
                    return LocationType.Originating;
            }
        }
    }
}
