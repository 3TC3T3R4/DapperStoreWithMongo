using AutoMapper;
using Domain.Entities.Entities;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {

        private readonly ISaleUseCase _saleUseCase;
        private readonly IMapper _mapper;


        public SaleController(ISaleUseCase saleUseCase, IMapper mapper)
        {
            _saleUseCase = saleUseCase;
            _mapper = mapper;
        }




        [HttpGet("{id:int}")]

        public async Task<SaleWithProductAndClient> Obtener_ProductQueCompro_By_Document(int id)
        {
            return await _saleUseCase.GetSaleById(id);
        }


    }
}
