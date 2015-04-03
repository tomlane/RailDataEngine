using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.TrainMovements
{
	public interface ITrainCallTypeProvider
	{
		TrainCallType? GetTrainCallType(string trainCallType);
	}
}