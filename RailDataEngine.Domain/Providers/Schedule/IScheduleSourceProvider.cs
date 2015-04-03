using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface IScheduleSourceProvider
	{
		ScheduleSource? GetScheduleSource(string scheduleSource);
	}
}