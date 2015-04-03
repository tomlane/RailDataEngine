namespace RailDataEngine.Domain.Providers.RailwayTime
{
	public interface IBankHolidayRunningProvider
	{
		bool? GetBankHolidayRunning(string runningIndicator);
	}
}
