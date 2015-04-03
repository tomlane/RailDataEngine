using RailDataEngine.Domain.Entities.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers.TrainMovements
{
	public interface IEventSourceProvider
	{
		EventSource? GetEventSource(string eventSource); 
	}
}