namespace RailDataEngine.Domain.Services.TimeConversionService
{
	public interface IRailwayMinutesProvider
	{
		int? GetRailwayMinutes(string timeString);
	}
}