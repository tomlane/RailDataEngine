using RailDataEngine.Domain.Entities.Schedule.Enums;

namespace RailDataEngine.Domain.Providers.Schedule
{
	public interface ITransactionTypeProvider
	{
		TransactionType? GetTransactionType(string transactionType);
	}
}