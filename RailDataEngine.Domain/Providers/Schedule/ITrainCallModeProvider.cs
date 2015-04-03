using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface ITrainCallModeProvider
	{
		TrainCallMode? GetTrainCallMode(string trainCallMode);
	}
}