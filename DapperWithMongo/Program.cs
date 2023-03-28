using AutoMapper.Data;
using Domain.UseCases.Gateway.Repository;
using Domain.UseCases.UseCases;
using Domain.UseCases;
using DapperStoreWithMongo.Automapper;
using DriverAdapterMongo.Repositories;
using DriverAdapterMongo.Interfaces;
using DriverAdapterMongo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(ConfigurationProfile));
builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("DefaultConnection"), "test"));



builder.Services.AddScoped<IClientUseCase, ClientUseCase>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

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
