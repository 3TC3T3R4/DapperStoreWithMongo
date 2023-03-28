using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWithMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IClientUseCase _clientUseCase;
        private readonly IMapper _mapper;

        public ClientController(IClientUseCase clientUseCase, IMapper mapper)
        {
            _clientUseCase = clientUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Client>> Obtener_List_Clients()
        {
            return await _clientUseCase.GetListClients();
        }

        [HttpPost]
        public async Task<Client> Create_Client([FromBody] InsertNewClient command)
        {   
            return await _clientUseCase.AddClient(_mapper.Map<Client  >(command));
        }


        [HttpPut("{id}")]
        public async Task<Client> Update_Client(string id, [FromBody] Client client)
        {
            return await _clientUseCase.UpdateClient(id,client);
        }

        [HttpDelete("{id}")]
        public async Task<Client> Delete_Client(int id)
        {
            return await _clientUseCase.DeleteClient(id);
        }


    }
}
