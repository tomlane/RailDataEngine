using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface IStpIndicationProvider
	{
		StpIndicator? GetStpIndicator(string stpIndicator);
	}
}