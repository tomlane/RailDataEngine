using RailDataEngine.Domain.Entity.Schedule.Enums;

namespace RailDataEngine.Domain.Providers
{
	public interface ITransactionTypeProvider
	{
		TransactionType? GetTransactionType(string transactionType);
	}
}