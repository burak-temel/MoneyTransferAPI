namespace MoneyTransferAPI.Core.DTOs.Transaction
{
    public class CreateTransactionDto
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }


}
