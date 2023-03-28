using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using DriverAdapterMongo.Enitities;
using System.IO;

namespace DapperStoreWithMongo.Automapper
{
    public class ConfigurationProfile:Profile
    {

        public ConfigurationProfile()
        {
            CreateMap<InsertNewClient, Client>().ReverseMap();
            CreateMap<ClientEntity, Client>().ReverseMap();

            CreateMap<InsertNewProduct, Product>().ReverseMap();
            CreateMap<InsertNewSale, Sale>().ReverseMap();



        }



    }
}
