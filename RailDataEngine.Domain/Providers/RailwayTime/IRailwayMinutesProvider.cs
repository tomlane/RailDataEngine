namespace RailDataEngine.Domain.Providers.RailwayTime
{
	public interface IRailwayMinutesProvider
	{
		int? GetRailwayMinutes(string timeString);
	}
}