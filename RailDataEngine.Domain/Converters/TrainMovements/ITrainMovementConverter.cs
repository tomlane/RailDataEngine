using RailDataEngine.Domain.Deserializers.TrainMovements.Entity.Json;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Converters.TrainMovements
{
	public interface ITrainMovementConverter
	{
		TrainMovement ConverTrainMovement(DeserializedJsonTrainMovement trainMovement);
	}
}