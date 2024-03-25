using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    /// <summary>
    /// Tipo da transação
    /// </summary>
    public enum TransactionType
    {
        Draw = 1,
        Withdraw = 2
    }

    /// <summary>
    /// Entidade de Transação
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Código da transação
        /// </summary>
        public Guid Id { get;  private set; }

        /// <summary>
        /// Código da Carteira
        /// </summary>
        public Guid WalletId { get;  private set; }

        /// <summary>
        /// <see cref="Entities.Product"/>
        /// </summary>
        public Product Product { get; private set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public double Quantity { get; private set; }

        /// <summary>
        /// <see cref="Entities.TransactionType"/>
        /// </summary>
        public TransactionType TransactionType { get; private set; }

        /// <summary>
        /// Data da operação
        /// </summary>
        public DateTime OperationDate { get; private set; }

        /// <summary>
        /// Instancia um <see cref="Transaction"/>
        /// </summary>
        /// <param name="id">código da transação</param>
        /// <param name="walletId">código da carteira</param>
        /// <param name="product"><see cref="Entities.Product"/></param>
        /// <param name="transactionType"><see cref="Entities.TransactionType"/></param>
        /// <param name="quantity">quantidade</param>
        /// <param name="operationDate">data da operação</param>
        public Transaction(Guid id, Guid walletId, Product product, TransactionType transactionType, double quantity, DateTime operationDate)
        {
            Id = id;
            WalletId = walletId;
            Product = product;
            Quantity = quantity;
            TransactionType = transactionType;
            OperationDate = operationDate;
        }

        /// <summary>
        /// Instancia um <see cref="Transaction"/>
        /// </summary>
        /// <param name="walletId">código da carteira</param>
        /// <param name="product"><see cref="Entities.Product"/></param>
        /// <param name="transactionType"><see cref="Entities.TransactionType"/></param>
        /// <param name="quantity">quantidade</param>
        /// <param name="operationDate">data da operação</param>
        public Transaction(Guid walletId, Product product, TransactionType transactionType, double quantity, DateTime operationDate)
        {
            Id = Guid.NewGuid();
            WalletId = walletId;
            Product = product;
            Quantity = quantity;
            TransactionType = transactionType;
            OperationDate = operationDate;
        }
    }
}
