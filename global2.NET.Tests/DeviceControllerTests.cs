using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class DeviceControllerTests
    {
        private readonly Mock<IRepository<Device>> _deviceRepositoryMock;
        private readonly DeviceController _deviceController;
        private readonly Device _validDevice;

        public DeviceControllerTests()
        {
            _deviceRepositoryMock = new Mock<IRepository<Device>>();
            _deviceController = new DeviceController(_deviceRepositoryMock.Object);

            _validDevice = new Device
            {
                IdDisp = 1,
                NomeDispositivo = "Smart Lamp",
                TipoDispositivo = "Lighting",
                StatusDispositivo = "On",
                UsuarioIdUsua = 1
            };
        }

        [Fact]
        public void PostDevice_ShouldAddDeviceAndReturnCreatedResult()
        {
            var result = _deviceController.PostDevice(_validDevice);

            _deviceRepositoryMock.Verify(repo => repo.Add(It.IsAny<Device>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_deviceController.GetAllDevices), createdResult.ActionName);
        }

        [Fact]
        public void GetAllDevices_ShouldReturnOkWithListOfDevices()
        {
            var devices = new List<Device> { _validDevice };
            _deviceRepositoryMock.Setup(repo => repo.GetAll()).Returns(devices);

            var result = _deviceController.GetAllDevices();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedDevices = Assert.IsType<List<Device>>(okResult.Value);
            Assert.Single(returnedDevices);
        }

        [Fact]
        public void PutDevice_ShouldUpdateDeviceAndReturnOk()
        {
            var result = _deviceController.PutDevice(_validDevice);

            _deviceRepositoryMock.Verify(repo => repo.Update(It.IsAny<Device>()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(_validDevice, okResult.Value);
        }

        [Fact]
        public void PutDevice_ShouldReturnBadRequest_WhenDeviceIdIsNull()
        {
            var invalidDevice = new Device
            {
                IdDisp = 0,
                NomeDispositivo = "Broken Device"
            };

            var result = _deviceController.PutDevice(invalidDevice);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteDevice_ShouldDeleteDeviceAndReturnOk()
        {
            _deviceRepositoryMock.Setup(repo => repo.Delete(It.IsAny<Device>()));

            var result = _deviceController.DeleteDevice(_validDevice);

            _deviceRepositoryMock.Verify(repo => repo.Delete(It.IsAny<Device>()), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}