using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using System.IO;

namespace DapperStore.Automapper
{
    public class ConfigurationProfile:Profile
    {

        public ConfigurationProfile()
        {
            CreateMap<InsertNewClient, Client>().ReverseMap();
            CreateMap<InsertNewProduct, Product>().ReverseMap();
            CreateMap<InsertNewSale, Sale>().ReverseMap();



        }



    }
}
