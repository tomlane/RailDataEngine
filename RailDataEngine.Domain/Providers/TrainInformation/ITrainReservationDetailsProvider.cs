using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.TrainInformation
{
	public interface ITrainReservationDetailsProvider
	{
		Reservations? GetTrainResevationDetails(string reservationDetails);
	}
}