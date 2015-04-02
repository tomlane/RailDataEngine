using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainCallModeProvider
	{
		TrainCallMode? GetTrainCallMode(string trainCallMode);
	}
}