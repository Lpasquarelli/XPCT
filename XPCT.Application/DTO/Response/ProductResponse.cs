using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Application.DTO.Response
{
    /// <summary>
    /// Resposta de Produto
    /// </summary>
    public class ProductResponse
    {
        /// <summary>
        /// Id do produto
        /// </summary>
        [SwaggerSchema(Description = "Código de identificação do produto")]
        public Guid Id { get; private set; }

        /// <summary>
        /// Nome do Produto
        /// </summary>
        [SwaggerSchema(Description = "Nome do produto")]
        public string? Name { get; private set; }

        /// <summary>
        /// Preço do produto
        /// </summary>
        [SwaggerSchema(Description = "Preço do produto")]
        public double Price { get; private set; }

        /// <summary>
        /// Flag de ativação do produto
        /// </summary>
        [SwaggerSchema(Description = "Flag de ativação do produto")]
        public bool Active { get; private set; }

        /// <summary>
        /// Dias para o vencimento do produto após compra
        /// </summary>
        [SwaggerSchema(Description = "Dias para o vencimento do produto após a compra")]
        public int DaysToDue { get; private set; }


        /// <summary>
        /// Instancia um <see cref="ProductResponse"/>
        /// </summary>
        /// <param name="id">codigo do produto</param>
        /// <param name="name">nome do produto</param>
        /// <param name="price">preço do produto</param>
        /// <param name="active">flag de ativaçao do produto</param>
        /// <param name="daysToDue">dias para o vencimento do produto após a compra</param>
        public ProductResponse(Guid id, string? name, double price, bool active, int daysToDue)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
            DaysToDue = daysToDue;
        }

        /// <summary>
        /// Instancia um <see cref="ProductResponse"/>
        /// </summary>
        /// <param name="product"><see cref="Product"/></param>
        public ProductResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Active = product.Active;
            DaysToDue = product.DaysToDue;
        }

        /// <summary>
        /// Método para conversão de <see cref="IEnumerable{T}"/> de <see cref="Product"/> em <see cref="IEnumerable{T}"/> de <see cref="ProductResponse"/>
        /// </summary>
        /// <param name="products"><see cref="IEnumerable{T}"/> de <see cref="Product"/></param>
        /// <returns></returns>
        public static IEnumerable<ProductResponse> ToResponseList(IEnumerable<Product> products) =>
            products.Select(_ => new ProductResponse(_));
    }
}
