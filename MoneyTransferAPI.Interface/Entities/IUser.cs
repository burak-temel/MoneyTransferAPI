using MoneyTransferAPI.Interface.DataAccess;

namespace MoneyTransferAPI.Interface.Entities
{
    public interface IUser : IEntity
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        decimal Balance { get; set; }
        byte[] PasswordHash { get; set; }
        byte[] PasswordSalt { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }
        bool Status { get; set; }
        string Currency { get; set; }
    }
}
