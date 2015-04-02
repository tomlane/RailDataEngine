using RailDataEngine.Domain.Entity.TrainMovements;
using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainDirectionProvider
	{
		Direction? GetTrainDirection(string direction);
	}
}
