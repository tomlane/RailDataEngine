using RailDataEngine.Domain.Deserializers.TrainMovements.Entity.Json;

namespace RailDataEngine.Domain.Deserializers.TrainMovements
{
	public interface ITrainMovementDeserializer
	{
		DeserializedJsonTrainMovement DeserializeTrainMovement(string trainMovement);
	}
}
