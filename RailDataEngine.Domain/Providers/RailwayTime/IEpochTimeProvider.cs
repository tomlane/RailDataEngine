using System;

namespace RailDataEngine.Domain.Services.TimeConversionService
{
	public interface IEpochTimeProvider
	{
		DateTime? GetEpochTimeFromMilliseconds(string timeString);
	}
}