using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.TrainInformation
{
	public interface ICateringCodeProvider
	{
		CateringCode? GetCateringCode(string cateringCode);
	}
}
