using XPCT.Domain.Entities;

namespace XPCT.Application.DTO.Response
{
    /// <summary>
    /// Resposta de Investimentos
    /// </summary>
    public class InvestmentsResponse
    {
        /// <summary>
        /// Lista de <see cref="Investment"/>
        /// </summary>
        public IEnumerable<Investment> Investments { get; private set; }

        /// <summary>
        /// Instancia um <see cref="InvestmentsResponse"/>
        /// </summary>
        /// <param name="investments"><see cref="IEnumerable{T}"/> T: <see cref="Investment"/></param>
        public InvestmentsResponse(IEnumerable<Investment> investments)
        {
            Investments = investments;
        }
    }
}
