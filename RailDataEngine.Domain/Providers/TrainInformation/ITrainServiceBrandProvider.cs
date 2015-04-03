using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.TrainInformation
{
	public interface ITrainServiceBrandProvider
	{
		ServiceBrand? GetTrainServiceBrand(string serviceBrand);
	}
}