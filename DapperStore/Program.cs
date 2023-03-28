using AutoMapper.Data;
using DapperStore.Automapper;
using Domain.UseCases;
using Domain.UseCases.Gateway.Repository;
using Domain.UseCases.UseCases;
using Infraestructure.DriverAdapter;
using Infraestructure.DriverAdapter.Gateway;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));


builder.Services.AddScoped<IClientUseCase, ClientUseCase>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddScoped<IProductUseCase, ProductUseCase>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ISaleUseCase, SaleUseCase>();

builder.Services.AddScoped<ISaleRepository, SaleRepository>();



builder.Services.AddTransient<IDbConnectionBuilder>(e =>
{
    return new DbConnectionBuilder(builder.Configuration.GetConnectionString("DefaultConnection"));
});



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

//app.UseMiddleware<ErrorHandleMiddleware>();

app.Run();
