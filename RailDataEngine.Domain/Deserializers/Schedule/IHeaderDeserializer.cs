using RailDataEngine.Domain.Deserializers.Schedule.Entity;

namespace RailDataEngine.Domain.Deserializers.Schedule
{
	public interface IHeaderDeserializer
	{
		DeserializedJsonScheduleHeader DeserializeHeader(string header);
	}
}