namespace XPCT.Domain.Entities
{
    /// <summary>
    /// Entidade de Carteira
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// Código da Carteira
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// <see cref="IEnumerable{T}"/> de <see cref="Investment"/>
        /// </summary>
        public List<Investment> Investments { get; private set; } = new();

        /// <summary>
        /// Instancia um <see cref="Wallet"/>
        /// </summary>
        /// <param name="id">código da carteira</param>
        /// <param name="investments"><see cref="IEnumerable{T}"/> de <see cref="Investment"/></param>
        public Wallet(Guid id, List<Investment> investments)
        {
            Id = id;
            Investments = investments;
        }

        /// <summary>
        /// Instancia um <see cref="Wallet"/>
        /// </summary>
        public Wallet()
        {
            Id = Guid.NewGuid();
        }
    }
}
