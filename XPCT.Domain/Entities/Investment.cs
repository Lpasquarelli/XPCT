using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    /// <summary>
    /// Entidade de Investimento
    /// </summary>
    public class Investment
    {
        /// <summary>
        /// <see cref="Product"/>
        /// </summary>
        public Product? Product { get; private set; }

        /// <summary>
        /// Quantidade
        /// </summary>
        public double Quantity { get; private set; }

        /// <summary>
        /// Data de Compra
        /// </summary>
        public DateTime PurchaseDate { get; private set; }

        /// <summary>
        /// Data de Vencimento
        /// </summary>
        public DateTime DueDate { get; private set; }

        /// <summary>
        /// Instancia um <see cref="Investment"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        /// <param name="quantity">quantidade</param>
        /// <param name="purchaseDate">data de compra</param>
        public Investment(Product product, double quantity, DateTime purchaseDate)
        {
            Product = product;
            Quantity = quantity;
            PurchaseDate = purchaseDate;
            DueDate = PurchaseDate.AddDays(Product.DaysToDue);
        }

        /// <summary>
        /// Somar Quantidade
        /// </summary>
        /// <param name="quantity">quantidade</param>
        public void SumQuantity(double  quantity)
        {
            Quantity += quantity;
        }

        /// <summary>
        /// Subtrair Quantidade
        /// </summary>
        /// <param name="quantity">quantidade</param>
        public void SubtractQuantity(double quantity)
        {
            Quantity -= quantity;
        }
    }
}
