using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace DapperStore.Controllers
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
        public async Task<List<Client>> Get_List_Clients()
        {
            return await _clientUseCase.GetListClients();
        }



        [HttpGet("{id:int}")]

        public async Task<Client> Obtener_Client_By_Id(int id)
        {
            return await _clientUseCase.GetClientById(id);
        }


        [HttpPost]
        public async Task<Client> Insert_Client([FromBody] InsertNewClient command)
        {
            return await _clientUseCase.AddClient(_mapper.Map<Client>(command));
        }


    }

}
