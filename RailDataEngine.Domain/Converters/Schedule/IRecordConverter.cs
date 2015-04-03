using RailDataEngine.Domain.Deserializers.Schedule.Entity;
using RailDataEngine.Domain.Entities.Schedule;

namespace RailDataEngine.Domain.Converters.Schedule
{
	public interface IRecordConverter
	{
		Record ConvertRecord(DeserializedJsonScheduleRecord record);
	}
}