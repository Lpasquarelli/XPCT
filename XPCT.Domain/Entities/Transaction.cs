using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    public enum TransactionType
    {
        Draw = 1,
        Withdraw = 2
    }
    public class Transaction
    {
        public Guid Id { get;  private set; }
        public Guid WalletId { get;  private set; }
        public Product Product { get; private set; }
        public double Quantity { get; private set; }
        public TransactionType TransactionType { get; private set; }
        public DateTime OperationDate { get; private set; }

        public Transaction(Guid id, Guid walletId, Product product, TransactionType transactionType, double quantity, DateTime operationDate)
        {
            Id = id;
            WalletId = walletId;
            Product = product;
            Quantity = quantity;
            TransactionType = transactionType;
            OperationDate = operationDate;
        }

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
