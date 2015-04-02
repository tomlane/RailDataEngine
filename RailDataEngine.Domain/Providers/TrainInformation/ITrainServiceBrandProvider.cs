using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITrainServiceBrandProvider
	{
		ServiceBrand? GetTrainServiceBrand(string serviceBrand);
	}
}