using RailDataEngine.Domain.Entities.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Providers.TrainDescriber
{
	public interface ISignalMessageTypeProvider
	{
		SignalMessageType? GetSinSignalMessageType(string signalMessageType);
	}
}