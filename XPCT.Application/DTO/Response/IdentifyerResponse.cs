using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Application.DTO.Response
{
    /// <summary>
    /// Resposta de Indentificação
    /// </summary>
    public class IdentifyerResponse
    {
        /// <summary>
        /// Id referente ao código do objeto manipulado
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Instancia um <see cref="IdentifyerResponse"/>
        /// </summary>
        /// <param name="id">código</param>
        public IdentifyerResponse(Guid id)
        {
            Id = id;
        }
    }
}
