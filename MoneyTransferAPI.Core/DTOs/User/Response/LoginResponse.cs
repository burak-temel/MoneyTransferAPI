
namespace MoneyTransferAPI.Core.DTOs.User.Response
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
    }
}
