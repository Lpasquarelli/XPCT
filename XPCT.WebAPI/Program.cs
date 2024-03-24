using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using System.Text;
using XPCT.Application.Interfaces;
using XPCT.Application.Services;
using XPCT.Domain.Repositories;
using XPCT.Infrastructure.Repositories;
using XPCT.WebAPI.Models.Request.Product;
using XPCT.WebAPI.Models.Request.User;
using XPCT.WebAPI.Models.Request.Wallet;
using XPCT.WebAPI.Validators.Product;
using XPCT.WebAPI.Validators.User;
using XPCT.WebAPI.Validators.Wallet;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

//Product Validations
builder.Services.AddTransient<IValidator<AddProductRequest>, AddProductRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateProductRequest>, UpdateProductRequestValidator>();
builder.Services.AddTransient<IValidator<EnableProductRequest>, EnableProductRequestValidator>();
//User Validations
builder.Services.AddTransient<IValidator<AddUserRequest>, AddUserRequestValidator>();
builder.Services.AddTransient<IValidator<GenerateUserTokenRequest>, GenerateUserTokenRequestValidator>();
//Walllet Validations
builder.Services.AddTransient<IValidator<BuyInvestmentsRequest>, BuyInvestmentsRequestValidator>();
builder.Services.AddTransient<IValidator<SellInvestmentsRequest>, SellInvestmentsRequestValidator>();

// Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWalletService, WalletService>();
builder.Services.AddScoped<IUserService, UserService>();

// Repositories
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IWalletRepository, WalletRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();


var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection("JWT:Key").Value);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer'[space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                }
            });
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
