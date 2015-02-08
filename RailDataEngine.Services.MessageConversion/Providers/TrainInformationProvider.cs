using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Providers;

namespace RailDataEngine.Services.MessageConversion.Providers
{
    public class TrainInformationProvider : ITrainInformationProvider
    {
        public TrainClass? GetTrainClass(string trainClass)
        {
            switch (trainClass)
            {
                case "S":
                    return TrainClass.StandardClassOnly;
                default:
                    return TrainClass.FirstAndStandardClass;
            }
        }

        public Sleepers? GetTrainSleeperDetails(string sleeperDetails)
        {
            if (string.IsNullOrWhiteSpace(sleeperDetails))
                return null;

            switch (sleeperDetails)
            {
                case "B":
                    return Sleepers.FirstAndStandard;
                case "F":
                    return Sleepers.FirstClassOnly;
                default:
                    return Sleepers.StandardClassOnly;
            }
        }

        public Reservations? GetTrainResevationDetails(string reservationDetails)
        {
            if (string.IsNullOrWhiteSpace(reservationDetails))
                return null;

            switch (reservationDetails)
            {
                case "A":
                    return Reservations.Compulsory;
                case "E":
                    return Reservations.BicyclesEssential;
                case "S":
                    return Reservations.PossibleFromAnyStation;
                default:
                    return Reservations.Reconmmended;
            }
        }

        public ServiceBrand? GetTrainServiceBrand(string serviceBrand)
        {
            switch (serviceBrand)
            {
                case "E":
                    return ServiceBrand.EuroStar;
                default:
                    return null;
            }
        }

        public CateringCode? GetCateringCode(string cateringCode)
        {
            if (string.IsNullOrWhiteSpace(cateringCode))
                return null;

            switch (cateringCode)
            {
                case "C":
                    return CateringCode.BuffetService;
                case "F":
                    return CateringCode.FirstClassRestaurant;
                case "H":
                    return CateringCode.HotFood;
                case "M":
                    return CateringCode.FirstClassMealIncluded;
                case "P":
                    return CateringCode.WheelChairOnly;
                case "R":
                    return CateringCode.Restaurant;
                default:
                    return CateringCode.TrolleyService;
            }
        }
    }
}
