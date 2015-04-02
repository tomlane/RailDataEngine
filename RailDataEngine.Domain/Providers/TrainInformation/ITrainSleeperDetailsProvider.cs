using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainSleeperDetailsProvider
	{
		Sleepers? GetTrainSleeperDetails(string sleeperDetails);
	}
}