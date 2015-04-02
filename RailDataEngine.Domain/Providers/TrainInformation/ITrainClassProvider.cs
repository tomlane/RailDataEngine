using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainClassProvider
	{
		TrainClass? GetTrainClass(string trainClass);
	}
}