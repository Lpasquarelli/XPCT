using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Application.DTO.Response
{
    public class InvestmentsResponse
    {
        public IEnumerable<Investment> Investments { get; private set; }

        public InvestmentsResponse(IEnumerable<Investment> investments)
        {
            Investments = investments;
        }
    }
}
