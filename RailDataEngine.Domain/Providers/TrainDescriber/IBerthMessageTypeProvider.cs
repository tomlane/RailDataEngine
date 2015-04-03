using RailDataEngine.Domain.Entities.TrainDescriber.Berth;

namespace RailDataEngine.Domain.Providers.TrainDescriber
{
	public interface IBerthMessageTypeProvider
	{
		BerthMessageType? GetBerthMessageType(string berthMessageType);
	}
}