using XPCT.Domain.Entities;

namespace XPCT.Application.DTO.Response
{
    /// <summary>
    /// Classe de resposta de extrato
    /// </summary>
    public class ExtractResponse
    {
        /// <summary>
        /// Lista de Transações
        /// <see cref="IEnumerable{T}"/> T: <see cref="Transaction"/>
        /// </summary>
        public IEnumerable<Transaction> Transactions { get;private  set; }

        /// <summary>
        /// Instancia um <see cref="ExtractResponse"/>
        /// </summary>
        /// <param name="transactions"><see cref="IEnumerable{T}"/> T: <see cref="Transaction"/></param>
        public ExtractResponse(IEnumerable<Transaction> transactions)
        {
            Transactions = transactions;
        }
    }
}
