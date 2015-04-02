using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IScheduleSourceProvider
	{
		ScheduleSource? GetScheduleSource(string scheduleSource);
	}
}