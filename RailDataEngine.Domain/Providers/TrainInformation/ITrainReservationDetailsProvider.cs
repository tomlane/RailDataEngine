using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainReservationDetailsProvider
	{
		Reservations? GetTrainResevationDetails(string reservationDetails);
	}
}