using RailDataEngine.Domain.Entity.Schedule;

namespace RailDataEngine.Domain.Providers
{
    public interface ITrainInformationProvider
    {
        TrainClass? GetTrainClass(string trainClass);
        Sleepers? GetTrainSleeperDetails(string sleeperDetails);
        Reservations? GetTrainResevationDetails(string reservationDetails);
        ServiceBrand? GetTrainServiceBrand(string serviceBrand);
        CateringCode? GetCateringCode(string cateringCode);
    }
}
