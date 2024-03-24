using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    public class Investment
    {
        public Product? Product { get; private set; }
        public double Quantity { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public DateTime DueDate { get; private set; }

        public Investment(Product product, double quantity, DateTime purchaseDate)
        {
            Product = product;
            Quantity = quantity;
            PurchaseDate = purchaseDate;
            DueDate = PurchaseDate.AddDays(Product.DaysToDue);
        }

        public void SumQuantity(double  quantity)
        {
            Quantity += quantity;
        }

        public void SubtractQuantity(double quantity)
        {
            Quantity -= quantity;
        }
    }
}
