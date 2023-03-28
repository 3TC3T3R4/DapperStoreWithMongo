using AutoMapper;
using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using DriverAdapterMongo.Enitities;
using DriverAdapterMongo.Interfaces;
using MongoDB.Bson;
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

        public async Task<Client> UpdateClientAsync(string idClient, Client client)
        {

            var filter = Builders<ClientEntity>.Filter.Eq(c => c.Id_Mongo   , idClient);
            var clientEntity = await coleccion.Find(filter).FirstOrDefaultAsync();

            clientEntity.id_client = client.id_client;
            clientEntity.id_number = client.id_number;
            clientEntity.type_id = client.type_id;
            clientEntity.name = client.name;


             await coleccion.ReplaceOneAsync(filter, clientEntity);

            return client;

        }


        public async Task<Client> DeleteClientAsync(int idClient)
        {

            var filter = Builders<ClientEntity>.Filter.Eq(c => c.id_client, idClient);
            var clientEntity = await coleccion.Find(filter).FirstOrDefaultAsync();
            clientEntity.state = false;




            await coleccion.ReplaceOneAsync(filter, clientEntity);

            return new Client
            {
                state = clientEntity.state

            };
                
        }




    }
}
