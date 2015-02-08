using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Providers;

namespace RailDataEngine.Services.MessageConversion
{
    public class ScheduleInformationProvider : IScheduleInformationProvider
    {
        public Category GetAssociationCategory(string associationType)
        {
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

        public TrainCallMode GetTrainCallMode(string trainCallMode)
        {
            switch (trainCallMode)
            {
                case "NORMAL":
                    return TrainCallMode.Normal;
                default:
                    return TrainCallMode.OverNight;
            }
        }

        public ScheduleType GetScheduleType(string scheduleType)
        {
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

        public ScheduleSource GetScheduleSource(string scheduleSource)
        {
            switch (scheduleSource)
            {
                case "C":
                    return ScheduleSource.Cif;
                default:
                    return ScheduleSource.Vstp;
            }
        }

        public StpIndicator GetStpIndicator(string stpIndicator)
        {
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

        public TransactionType GetTransactionType(string transactionType)
        {
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

        public DateIndicator GetDateIndicator(string dateIndicator)
        {
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
    }
}
