using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XPCT.Domain.Entities
{
    /// <summary>
    /// Entidade de Produto
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Código do produto
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Nome do Produto
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Preço do produto
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Flag de ativação do produto
        /// </summary>
        public bool Active { get;private set; }

        /// <summary>
        /// quantidade de dias para o vencimento após a compra
        /// </summary>
        public int DaysToDue { get; private set; }

        /// <summary>
        /// Instancia um <see cref="Product"/>
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <param name="name">nome do Produto</param>
        /// <param name="price">Preço do Produto</param>
        /// <param name="active">Flag de Ativação do produto</param>
        /// <param name="daysToDue">Dias para vencimento após a compra</param>
        public Product(Guid id, string name, double price, bool active, int daysToDue)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Active = active;
            this.DaysToDue = daysToDue;
        }

        /// <summary>
        /// Instancia um <see cref="Product"/>
        /// </summary>
        /// <param name="id">código do produto</param>
        /// <param name="name">nome do Produto</param>
        /// <param name="price">Preço do Produto</param>
        /// <param name="daysToDue">Dias para vencimento após a compra</param>
        public Product(Guid id, string name, double price, int daysToDue)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.DaysToDue = daysToDue;
        }

        /// <summary>
        /// Instancia um <see cref="Product"/>
        /// </summary>
        /// <param name="name">nome do Produto</param>
        /// <param name="price">Preço do Produto</param>
        /// <param name="active">Flag de Ativação do produto</param>
        /// <param name="daysToDue">Dias para vencimento após a compra</param>
        public Product(string name, double price, bool active, int daysToDue)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
            this.Active = active;
            this.DaysToDue = daysToDue;
        }

        /// <summary>
        /// Altera um produto
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public void Update(Product product)
        {
            this.Name = product.Name;
            this.Price = product.Price;
            this.DaysToDue = product.DaysToDue;
        }

        /// <summary>
        /// Ativa um produto
        /// </summary>
        public void Enable()
        {
            this.Active = true;
        }

        /// <summary>
        /// inativa um produto
        /// </summary>
        public void Disable()
        {
            this.Active = false;
        }
    }
}
