using RailDataEngine.Domain.Deserializers.TrainMovements.Entity.Json;

namespace RailDataEngine.Domain.Deserializers.TrainMovements
{
	public interface ITrainActivationDeserializer
	{
		DeserializedJsonTrainActivation DeserializeTrainActivation(string trainActivation);
	}
}