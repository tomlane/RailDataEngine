using System;

namespace RailDataEngine.Domain.Providers.RailwayTime
{
	public interface IEpochTimeProvider
	{
		DateTime? GetEpochTimeFromMilliseconds(string timeString);
	}
}