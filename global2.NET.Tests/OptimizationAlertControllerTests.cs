using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class OptimizationAlertControllerTests
    {
        private readonly Mock<IRepository<OptimizationAlert>> _alertRepositoryMock;
        private readonly OptimizationAlertController _optimizationAlertController;
        private readonly OptimizationAlert _validAlert;

        public OptimizationAlertControllerTests()
        {
            _alertRepositoryMock = new Mock<IRepository<OptimizationAlert>>();
            _optimizationAlertController = new OptimizationAlertController(_alertRepositoryMock.Object);

            _validAlert = new OptimizationAlert
            {
                IdAler = 1,
                TipoAlerta = "Energy Saving",
                Descricao = "Reduce energy consumption by 20%",
                DataAlerta = DateTime.Now,
                TelefoneIdTelef = 1
            };
        }

        [Fact]
        public void Post_ShouldAddAlertAndReturnCreatedResult()
        {
            var result = _optimizationAlertController.Post(_validAlert);

            _alertRepositoryMock.Verify(repo => repo.Add(It.IsAny<OptimizationAlert>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_optimizationAlertController.GetAllAlerts), createdResult.ActionName);
        }

        [Fact]
        public void GetAllAlerts_ShouldReturnOkWithListOfAlerts()
        {
            var alerts = new List<OptimizationAlert> { _validAlert };
            _alertRepositoryMock.Setup(repo => repo.GetAll()).Returns(alerts);

            var result = _optimizationAlertController.GetAllAlerts();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedAlerts = Assert.IsType<List<OptimizationAlert>>(okResult.Value);
            Assert.Single(returnedAlerts);
        }
    }
}