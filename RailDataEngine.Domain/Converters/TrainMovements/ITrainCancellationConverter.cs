using RailDataEngine.Domain.Deserializers.TrainMovements.Entity.Json;
using RailDataEngine.Domain.Entities.TrainMovements;

namespace RailDataEngine.Domain.Converters.TrainMovements
{
	public interface ITrainCancellationConverter
	{
		TrainCancellation ConveTrainCancellation(DeserializedJsonTrainCancellation trainCancellation);
	}
}