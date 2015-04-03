using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.TrainMovements
{
	public interface IVariationStatusProvider
	{
		VariationStatus? GetVariationStatus(string variationStatus);
	}
}