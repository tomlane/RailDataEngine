using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ILocationTypeProvider
	{
		LocationType? GetLocationType(string locationType);
	}
}
