namespace RailDataEngine.Domain.Services.TimeConversionService
{
	public interface IBankHolidayRunningProvider
	{
		bool? GetBankHolidayRunning(string runningIndicator);
	}
}
