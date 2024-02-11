using MoneyTransferAPI.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransferAPI.Core.Entities
{
    public class User: IUser
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string Email { get ; set ; }
        public bool Status { get; set; }

        //Doldurulmayacak alanlar
        public ICollection<Transaction> SentTransactions { get; set; }
        public ICollection<Transaction> ReceivedTransactions { get; set; }
    }
}
