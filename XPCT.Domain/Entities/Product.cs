using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public double Price { get; private set; }
        public bool Active { get;private set; }
        public int DaysToDue { get; private set; }

        public Product(Guid id, string name, double price, bool active, int daysToDue)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Active = active;
            this.DaysToDue = daysToDue;
        }
        public Product(Guid id, string name, double price, int daysToDue)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.DaysToDue = daysToDue;
        }

        public Product(string name, double price, bool active, int daysToDue)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
            this.Active = active;
            this.DaysToDue = daysToDue;
        }

        public void Update(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.DaysToDue = product.DaysToDue;
        }

        public void Enable()
        {
            this.Active = true;
        }

        public void Disable()
        {
            this.Active = false;
        }
    }
}
