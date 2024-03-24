using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Application.DTO.Response
{
    public class ExtractResponse
    {
        public IEnumerable<Transaction> Transactions { get;private  set; }

        public ExtractResponse(IEnumerable<Transaction> transactions)
        {
            Transactions = transactions;
        }
    }
}
