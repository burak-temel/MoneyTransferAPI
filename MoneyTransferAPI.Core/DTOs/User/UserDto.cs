namespace MoneyTransferAPI.Core.DTOs.User
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}