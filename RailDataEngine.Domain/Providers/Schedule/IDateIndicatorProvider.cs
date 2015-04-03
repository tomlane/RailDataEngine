using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface IDateIndicatorProvider
	{
		DateIndicator? GetDateIndicator(string dateIndicator);
	}
}