using AutoMapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using DriverAdapterMongo.Enitities;
using DriverAdapterMongo.Interfaces;
using MongoDB.Driver;


namespace DriverAdapterMongo.Repositories
{
    public class ClientRepository: IClientRepository
    {
        private readonly IMongoCollection<ClientEntity> coleccion;
        private readonly IMapper _mapper;

        public ClientRepository(IContext context, IMapper mapper)
        {
            this.coleccion = context.Client;
            _mapper = mapper;
        }

        public async Task<List<Client>> GetAllClientsAsync()
        {
            //var client = await coleccion.FindAsync(Builders<ClientEntity>.Filter.Empty);

            //var listClient = client.ToEnumerable().Select(client => _mapper.Map<Client>(client)).ToList();
            //return listClient;
            var filter = Builders<ClientEntity>.Filter.Eq(c => c.state, true);

            var client = await coleccion.FindAsync(filter);

            var listClient = client.ToEnumerable().Select(client => _mapper.Map<Client>(client)).ToList();
            return listClient;


        }

        public Task<Client> GetClientByIdAsync(int idClient)
        {
            throw new NotImplementedException();
        }

        public async Task<Client> InsertClientAsync(Client client)
        {
            var clientGuardar = _mapper.Map<ClientEntity>(client);
            await coleccion.InsertOneAsync(clientGuardar);
            return client;
        }

        public Task<Client> InsertClientSqlKataAsync(Client client)
        {
            throw new NotImplementedException();
        }



    }
}
