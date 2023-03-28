using Domain.Entities.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Gateway.Repository
{
    public interface IClientRepository
    {
        Task<Client> InsertClientAsync(Client client);

        Task<List<Client>> GetAllClientsAsync();

        Task<Client> GetClientByIdAsync(int idClient);

        Task<Client> InsertClientSqlKataAsync(Client client);



    }
}
