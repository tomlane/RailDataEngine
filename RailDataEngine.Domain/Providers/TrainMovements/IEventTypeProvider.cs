using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.TrainMovements
{
	public interface IEventTypeProvider
	{
		EventType? GetEventType(string eventType);
	}
}