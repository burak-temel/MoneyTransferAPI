using MoneyTransferAPI.Enums;
using MoneyTransferAPI.Interface.DataAccess;

namespace MoneyTransferAPI.Interface.Entities
{
    public interface ITransaction : IEntity
    {
        Guid Id { get; set; }
        Guid SenderId { get; set; }
        Guid ReceiverId { get; set; }
        decimal Amount { get; set; }
        string Currency { get; set; }
        DateTime TransactionDate { get; set; }
        TransactionStatus Status { get; set; }
    }
}
