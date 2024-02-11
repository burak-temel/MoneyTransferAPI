using MediatR;
using MoneyTransferAPI.Core.DTOs.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransferAPI.Core.Queries.Transaction
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<TransactionDto>>
    {
    }

}
