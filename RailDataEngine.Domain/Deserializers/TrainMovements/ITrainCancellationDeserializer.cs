using RailDataEngine.Domain.Deserializers.TrainMovements.Entity.Json;

namespace RailDataEngine.Domain.Deserializers.TrainMovements
{
	public interface ITrainCancellationDeserializer
	{
		DeserializedJsonTrainCancellation DeserializeTrainCancellation(string trainCancellation);
	}
}