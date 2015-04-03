using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.TrainMovements
{
	public interface ICancellationTypeProvider
	{
		CancellationType? GetCancellationType(string cancellationType);
	}
}