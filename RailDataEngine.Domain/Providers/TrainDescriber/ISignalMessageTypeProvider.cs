using RailDataEngine.Domain.Entity.TrainDescriber.Signal;

namespace RailDataEngine.Domain.Providers.TrainDescriber
{
	public interface ISignalMessageTypeProvider
	{
		SignalMessageType? GetSinSignalMessageType(string signalMessageType);
	}
}