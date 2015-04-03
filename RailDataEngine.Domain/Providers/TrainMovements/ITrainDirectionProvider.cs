using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.TrainMovements
{
	public interface ITrainDirectionProvider
	{
		Direction? GetTrainDirection(string direction);
	}
}
