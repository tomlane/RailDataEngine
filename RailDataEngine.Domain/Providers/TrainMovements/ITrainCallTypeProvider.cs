using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainCallTypeProvider
	{
		TrainCallType? GetTrainCallType(string trainCallType);
	}
}