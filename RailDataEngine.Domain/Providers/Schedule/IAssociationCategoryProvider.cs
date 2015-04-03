using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface IAssociationCategoryProvider
	{
		Category? GetAssociationCategory(string associationCategory);
	}
}