using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPCT.Domain.Entities;

namespace XPCT.Application.DTO.Response
{
    public class ProductResponse
    {
        [SwaggerSchema(Description = "Código de identificação do produto")]
        public Guid Id { get; private set; }
        [SwaggerSchema(Description = "Nome do produto")]
        public string? Name { get; private set; }
        [SwaggerSchema(Description = "Preço do produto")]
        public double Price { get; private set; }
        [SwaggerSchema(Description = "Flag de ativação do produto")]
        public bool Active { get; private set; }
        [SwaggerSchema(Description = "Dias para o vencimento do produto após a compra")]
        public int DaysToDue { get; private set; }

        public ProductResponse(Guid id, string? name, double price, bool active, int daysToDue)
        {
            Id = id;
            Name = name;
            Price = price;
            Active = active;
            DaysToDue = daysToDue;
        }

        public ProductResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Active = product.Active;
            DaysToDue = product.DaysToDue;
        }

        public static IEnumerable<ProductResponse> ToResponseList(IEnumerable<Product> products) =>
            products.Select(_ => new ProductResponse(_));
    }
}
