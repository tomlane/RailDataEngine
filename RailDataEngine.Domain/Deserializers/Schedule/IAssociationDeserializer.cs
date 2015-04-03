using RailDataEngine.Domain.Deserializers.Schedule.Entity;

namespace RailDataEngine.Domain.Deserializers.Schedule
{
	public interface IAssociationDeserializer
	{
		DeserializedJsonAssociation DeserializeAssociation(string association);
	}
}