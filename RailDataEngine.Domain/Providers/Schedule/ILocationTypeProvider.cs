using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface ILocationTypeProvider
	{
		LocationType? GetLocationType(string locationType);
	}
}
