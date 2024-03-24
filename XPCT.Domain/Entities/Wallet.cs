using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; private set; }
        public List<Investment> Investments { get; private set; } = new();

        public Wallet(Guid id, List<Investment> investments)
        {
            Id = id;
            Investments = investments;
        }

        public Wallet()
        {
            Id = Guid.NewGuid();
        }
    }
}
