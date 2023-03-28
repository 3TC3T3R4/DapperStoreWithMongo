using Domain.Entities.Entities;

namespace Domain.UseCases
{
    public interface IClientUseCase
    {
        Task<Client> AddClient(Client client);

        Task<List<Client>> GetListClients();

        Task<Client> GetClientById(int id);

        Task<Client> InsertClientConKata(Client client);

        Task<Client> UpdateClient(int id, Client client);



    }
}
