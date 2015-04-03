using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.TrainInformation
{
	public interface ITrainSleeperDetailsProvider
	{
		Sleepers? GetTrainSleeperDetails(string sleeperDetails);
	}
}