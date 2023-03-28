using Domain.Entities.Entities;
using Domain.UseCases.Gateway.Repository;
using Domain.UseCases.UseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDapper.TestClient
{
    public class ClientTestCasoDeUso
    {
        [Fact]
        public async Task GetListClients()
        {

            var clientRepositorioMock = new Mock<IClientRepository>();

            clientRepositorioMock.Setup(x => x.GetAllClientsAsync()).ReturnsAsync(new List<Client>());
            var clientCasoDeUso = new ClientUseCase(clientRepositorioMock.Object);
            var result = await clientCasoDeUso.GetListClients();
            Assert.NotNull(result);
            Assert.IsType<List<Client>>(result);

        }

        [Fact]
        public async Task AddClient()
        {

            var clientRepositorioMock = new Mock<IClientRepository>();

            clientRepositorioMock.Setup(x => x.InsertClientAsync(It.IsAny<Client>())).ReturnsAsync(new Client());
            var pacienteCasoDeUso = new ClientUseCase(clientRepositorioMock.Object);
            var result = await pacienteCasoDeUso.AddClient(new Client());
            Assert.NotNull(result);
            Assert.IsType<Client>(result);
        }

        [Fact]
        public async Task getClientById()
        {

            var clientRepositorioMock = new Mock<IClientRepository>();

            clientRepositorioMock.Setup(x => x.GetClientByIdAsync(It.IsAny<int>())).ReturnsAsync(new Client());
            var clientCasoDeUso = new ClientUseCase(clientRepositorioMock.Object);
            var result = await clientCasoDeUso.GetClientById(1);
            Assert.NotNull(result);
            Assert.IsType<Client>(result);
        }








    }
}
