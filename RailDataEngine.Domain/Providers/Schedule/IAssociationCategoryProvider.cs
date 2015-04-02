using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface IAssociationCategoryProvider
	{
		Category? GetAssociationCategory(string associationCategory);
	}
}