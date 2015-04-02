using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IScheduleTypeProvider
	{
		ScheduleType? GetScheduleType(string scheduleType);
	}
}