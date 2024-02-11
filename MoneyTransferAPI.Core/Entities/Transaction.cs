using MoneyTransferAPI.Enums;
using MoneyTransferAPI.Interface.Entities;

namespace MoneyTransferAPI.Core.Entities
{
    public class Transaction : ITransaction
    {
        public Guid Id { get; set; }

        public User Sender { get; set; }
        public Guid SenderId { get; set; }
        public User Receiver { get; set; }
        public Guid ReceiverId { get; set; }

        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
