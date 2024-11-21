using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class ContactNumberControllerTests
    {
        private readonly Mock<IRepository<ContactNumber>> _telephoneRepositoryMock;
        private readonly ContactNumberController _contactNumberController;
        private readonly ContactNumber _validContactNumber;

        public ContactNumberControllerTests()
        {
            _telephoneRepositoryMock = new Mock<IRepository<ContactNumber>>();
            _contactNumberController = new ContactNumberController(_telephoneRepositoryMock.Object);

            _validContactNumber = new ContactNumber
            {
                IdTelef = 1,
                CodigoPais = "+55",
                DDD = "11",
                NumeroTelefone = "987654321",
                UsuarioIdUsua = 1
            };
        }

        [Fact]
        public void PostTelephone_ShouldAddContactNumberAndReturnCreatedResult()
        {
            var result = _contactNumberController.PostTelephone(_validContactNumber);

            _telephoneRepositoryMock.Verify(repo => repo.Add(It.IsAny<ContactNumber>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_contactNumberController.GetAllTelephone), createdResult.ActionName);
        }

        [Fact]
        public void GetAllTelephone_ShouldReturnOkWithListOfContactNumbers()
        {
            var contactNumbers = new List<ContactNumber> { _validContactNumber };
            _telephoneRepositoryMock.Setup(repo => repo.GetAll()).Returns(contactNumbers);

            var result = _contactNumberController.GetAllTelephone();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedNumbers = Assert.IsType<List<ContactNumber>>(okResult.Value);
            Assert.Single(returnedNumbers);
        }

        [Fact]
        public void PutTelephone_ShouldUpdateContactNumberAndReturnOk()
        {
            var result = _contactNumberController.PutTelephone(_validContactNumber);

            _telephoneRepositoryMock.Verify(repo => repo.Update(It.IsAny<ContactNumber>()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(_validContactNumber, okResult.Value);
        }

        [Fact]
        public void PutTelephone_ShouldReturnBadRequest_WhenContactNumberIdIsNull()
        {
            var invalidContactNumber = new ContactNumber
            {
                IdTelef = 0, // Simulating invalid ID
                CodigoPais = "+55",
                DDD = "21",
                NumeroTelefone = "123456789"
            };

            var result = _contactNumberController.PutTelephone(invalidContactNumber);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteTelephone_ShouldDeleteContactNumberAndReturnOk()
        {
            _telephoneRepositoryMock.Setup(repo => repo.Delete(It.IsAny<ContactNumber>()));

            var result = _contactNumberController.DeleteTelephone(_validContactNumber);

            _telephoneRepositoryMock.Verify(repo => repo.Delete(It.IsAny<ContactNumber>()), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}