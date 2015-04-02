using RailDataEngine.Domain.Entity.TrainMovements.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IEventSourceProvider
	{
		EventSource? GetEventSource(string eventSource); 
	}
}