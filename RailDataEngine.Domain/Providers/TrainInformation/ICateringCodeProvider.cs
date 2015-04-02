using RailDataEngine.Domain.Entity.Schedule;
using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ICateringCodeProvider
	{
		CateringCode? GetCateringCode(string cateringCode);
	}
}
