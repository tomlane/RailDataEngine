using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IEventTypeProvider
	{
		EventType? GetEventType(string eventType);
	}
}