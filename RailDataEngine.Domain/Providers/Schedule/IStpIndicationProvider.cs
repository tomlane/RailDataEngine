using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IStpIndicationProvider
	{
		StpIndicator? GetStpIndicator(string stpIndicator);
	}
}