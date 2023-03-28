using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UseCases
{
   public class ClientUseCase : IClientUseCase
    {

        private readonly IClientRepository _clientRepository;

        public ClientUseCase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<Client> AddClient(Client client)
        {
            return await _clientRepository.InsertClientAsync(client);
        }

        public async Task<Client> InsertClientConKata(Client client)
        {
            return await _clientRepository.InsertClientAsync(client);
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _clientRepository.GetClientByIdAsync(id);
        }

        public async Task<List<Client>> GetListClients()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        public async Task<Client> UpdateClient(string id, Client client)
        {
            return await _clientRepository.UpdateClientAsync(id, client);
        }

        public async Task<Client> DeleteClient(int id)
        {
            return await _clientRepository.DeleteClientAsync(id);
        }



    }
}
