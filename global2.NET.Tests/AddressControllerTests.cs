using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class AddressControllerTests
    {
        private readonly Mock<IRepository<Address>> _addressRepositoryMock;
        private readonly AddressController _addressController;
        private readonly Address _validAddress;

        public AddressControllerTests()
        {
            _addressRepositoryMock = new Mock<IRepository<Address>>();
            _addressController = new AddressController(_addressRepositoryMock.Object);

            _validAddress = new Address
            {
                IdEnde = 1,
                Logradouro = "Rua Exemplo",
                CEP = "12345-678",
                Numero = "100",
                Complemento = "Apto 101",
                Bairro = "Centro",
                Cidade = "Exemplo City",
                Estado = "EX",
                UsuarioIdUsua = 1
            };
        }

        [Fact]
        public void PostUser_ShouldAddAddressAndReturnCreatedResult()
        {
            var result = _addressController.PostUser(_validAddress);

            _addressRepositoryMock.Verify(repo => repo.Add(It.IsAny<Address>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_addressController.GetAllAddress), createdResult.ActionName);
        }

        [Fact]
        public void GetAllAddress_ShouldReturnOkWithListOfAddresses()
        {
            var addresses = new List<Address> { _validAddress };
            _addressRepositoryMock.Setup(repo => repo.GetAll()).Returns(addresses);

            var result = _addressController.GetAllAddress();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedAddresses = Assert.IsType<List<Address>>(okResult.Value);
            Assert.Single(returnedAddresses);
        }

        [Fact]
        public void PutAddress_ShouldUpdateAddressAndReturnNoContent()
        {
            var result = _addressController.PutAddress(_validAddress);

            _addressRepositoryMock.Verify(repo => repo.Update(It.IsAny<Address>()), Times.Once);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void PutAddress_ShouldReturnBadRequest_WhenAddressIdIsNull()
        {
            var invalidAddress = new Address
            {
                IdEnde = 0,
                Logradouro = "Rua InvÃ¡lida"
            };

            var result = _addressController.PutAddress(invalidAddress);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteAddress_ShouldDeleteAddressAndReturnNoContent()
        {
            _addressRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns(_validAddress);

            var result = _addressController.DeleteAddress((int)_validAddress.IdEnde);

            _addressRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Address>()), Times.Once);
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteAddress_ShouldReturnNotFound_WhenAddressDoesNotExist()
        {
            _addressRepositoryMock.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Address)null);

            var result = _addressController.DeleteAddress(999);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}