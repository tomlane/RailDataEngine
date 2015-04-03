using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.TrainInformation
{
	public interface ITrainClassProvider
	{
		TrainClass? GetTrainClass(string trainClass);
	}
}