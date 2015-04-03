using RailDataEngine.Domain.Deserializers.Schedule.Entity;

namespace RailDataEngine.Domain.Deserializers.Schedule
{
	public interface IRecordDeserializer
	{
		DeserializedJsonScheduleRecord DeserializeRecord(string record);
	}
}