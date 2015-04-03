using RailDataEngine.Domain.Deserializers.Schedule.Entity;

namespace RailDataEngine.Domain.Deserializers.Schedule
{
	public interface ITiplocDeserializer
	{
		DeserializedJsonTiploc DeserializeTiploc(string tiploc);
	}
}
