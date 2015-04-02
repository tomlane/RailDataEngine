using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ICancellationTypeProvider
	{
		CancellationType? GetCancellationType(string cancellationType);
	}
}