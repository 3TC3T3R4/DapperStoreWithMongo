using AutoMapper;
using Domain.Entities.Commands;
using Domain.Entities.Entities;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class ProductController : ControllerBase
        {

            private readonly IProductUseCase _productUseCase;
            private readonly IMapper _mapper;


            public ProductController(IProductUseCase productUseCase, IMapper mapper)
            {
                _productUseCase = productUseCase;
                _mapper = mapper;
            }


            [HttpGet]
            public async Task<List<Product>> Get_List_Products()
            {
                return await _productUseCase.GetListProducts();
            }



            [HttpGet("{id:int}")]

            public async Task<Product> Obtener_Product_By_Id(int id)
            {
                return await _productUseCase.GetProductById(id);
            }


            [HttpPost]
            public async Task<Product> Insert_Product([FromBody] InsertNewProduct command)
            {
                return await _productUseCase.AddProduct(_mapper.Map<Product>(command));
            }

        
    }
}

