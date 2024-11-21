using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class EnergyLectureControllerTests
    {
        private readonly Mock<IRepository<Database.Models.EnergyLecture>> _energyLRepositoryMock;
        private readonly EnergyLectureController _energyLectureController;
        private readonly EnergyLecture _validLecture;

        public EnergyLectureControllerTests()
        {
            _energyLRepositoryMock = new Mock<IRepository<EnergyLecture>>();
            _energyLectureController = new EnergyLectureController(_energyLRepositoryMock.Object);

            _validLecture = new EnergyLecture
            {
                Id = 1,
                Consumo = "150 kWh",
                ProducaoEnergia = "50 kWh",
                DataLeitura = DateTime.Now
            };
        }

        [Fact]
        public void PostLecture_ShouldAddLectureAndReturnCreatedResult()
        {
            var result = _energyLectureController.PostLecture(_validLecture);

            _energyLRepositoryMock.Verify(repo => repo.Add(It.IsAny<EnergyLecture>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_energyLectureController.GetAllLecture), createdResult.ActionName);
        }

        [Fact]
        public void GetAllLecture_ShouldReturnOkWithListOfLectures()
        {
            var lectures = new List<EnergyLecture> { _validLecture };
            _energyLRepositoryMock.Setup(repo => repo.GetAll()).Returns(lectures);

            var result = _energyLectureController.GetAllLecture();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedLectures = Assert.IsType<List<EnergyLecture>>(okResult.Value);
            Assert.Single(returnedLectures);
        }

        [Fact]
        public void PutLecture_ShouldUpdateLectureAndReturnOk()
        {
            var result = _energyLectureController.PutLecture(_validLecture);

            _energyLRepositoryMock.Verify(repo => repo.Update(It.IsAny<EnergyLecture>()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(_validLecture, okResult.Value);
        }

        [Fact]
        public void PutLecture_ShouldReturnBadRequest_WhenLectureIdIsNull()
        {
            var invalidLecture = new EnergyLecture
            {
                Id = 0,
                Consumo = "100 kWh"
            };

            var result = _energyLectureController.PutLecture(invalidLecture);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteLecture_ShouldDeleteLectureAndReturnOk()
        {
            _energyLRepositoryMock.Setup(repo => repo.Delete(It.IsAny<EnergyLecture>()));

            var result = _energyLectureController.DeleteLecture(_validLecture);

            _energyLRepositoryMock.Verify(repo => repo.Delete(It.IsAny<EnergyLecture>()), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}