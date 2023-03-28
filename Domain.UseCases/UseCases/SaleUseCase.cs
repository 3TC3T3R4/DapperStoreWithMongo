using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.UseCases
{
    public class SaleUseCase : ISaleUseCase
    {

        private readonly ISaleRepository _saleRepository;

        public SaleUseCase(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<SaleWithProductAndClient> GetSaleById(int id)
        {
            return await _saleRepository.GetSaleByIdAsync(id);
        }





    }
}
