using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface IScheduleTypeProvider
	{
		ScheduleType? GetScheduleType(string scheduleType);
	}
}