using FluentValidation;
using Microsoft.OpenApi.Models;
using XPCT.Application.Interfaces;
using XPCT.Application.Services;
using XPCT.Domain.Repositories;
using XPCT.Infrastructure.Repositories;
using XPCT.WebAPI.Models.Request.Product;
using XPCT.WebAPI.Validators.Product;

var builder = WebApplication.CreateBuilder(args);

// Validations
builder.Services.AddTransient<IValidator<AddProductRequest>, AddProductRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();
builder.Services.AddTransient<IValidator<EnableProductRequest>, EnableProductRequestValidator>();

// Services.
builder.Services.AddScoped<IProductService, ProductService>();

// Repositories
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Case Técnico - Entrevista XP",
            Description = "Sistema de Gestão de Portfólio de Investimentos."
        });
    }
);
builder.Services.AddApiVersioning();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
