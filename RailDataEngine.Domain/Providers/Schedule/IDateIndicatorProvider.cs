using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IDateIndicatorProvider
	{
		DateIndicator? GetDateIndicator(string dateIndicator);
	}
}