using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Application.DTO.Response
{
    public class IdentifyerResponse
    {
        public Guid Id { get; private set; }

        public IdentifyerResponse(Guid id)
        {
            Id = id;
        }
    }
}
