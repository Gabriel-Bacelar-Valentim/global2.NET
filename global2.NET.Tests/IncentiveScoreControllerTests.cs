using global2.NET.Controllers;
using global2.NET.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace global2.NET.Tests
{
    public class IncentiveScoreControllerTests
    {
        private readonly Mock<IRepository<IncentiveScore>> _scoreRepositoryMock;
        private readonly IncentiveScoreController _incentiveScoreController;
        private readonly IncentiveScore _validScore;

        public IncentiveScoreControllerTests()
        {
            _scoreRepositoryMock = new Mock<IRepository<IncentiveScore>>();
            _incentiveScoreController = new IncentiveScoreController(_scoreRepositoryMock.Object);

            _validScore = new IncentiveScore
            {
                IdPont = 1,
                PontosAdquiridos = 100,
                MetaAlcancada = 1,
                DataPontuacao = DateTime.Now
            };
        }

        [Fact]
        public void PostScore_ShouldAddScoreAndReturnCreatedResult()
        {
            var result = _incentiveScoreController.PostScore(_validScore);

            _scoreRepositoryMock.Verify(repo => repo.Add(It.IsAny<IncentiveScore>()), Times.Once);
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_incentiveScoreController.GetAllScores), createdResult.ActionName);
        }

        [Fact]
        public void GetAllScores_ShouldReturnOkWithListOfScores()
        {
            var scores = new List<IncentiveScore> { _validScore };
            _scoreRepositoryMock.Setup(repo => repo.GetAll()).Returns(scores);

            var result = _incentiveScoreController.GetAllScores();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedScores = Assert.IsType<List<IncentiveScore>>(okResult.Value);
            Assert.Single(returnedScores);
        }

        [Fact]
        public void PutScore_ShouldUpdateScoreAndReturnOk()
        {
            var result = _incentiveScoreController.PutScore(_validScore);

            _scoreRepositoryMock.Verify(repo => repo.Update(It.IsAny<IncentiveScore>()), Times.Once);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(_validScore, okResult.Value);
        }

        [Fact]
        public void PutScore_ShouldReturnBadRequest_WhenScoreIdIsNull()
        {
            var invalidScore = new IncentiveScore
            {
                IdPont = 0,
                PontosAdquiridos = 50
            };

            var result = _incentiveScoreController.PutScore(invalidScore);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void DeleteScore_ShouldDeleteScoreAndReturnOk()
        {
            _scoreRepositoryMock.Setup(repo => repo.Delete(It.IsAny<IncentiveScore>()));

            var result = _incentiveScoreController.DeleteScore(_validScore);

            _scoreRepositoryMock.Verify(repo => repo.Delete(It.IsAny<IncentiveScore>()), Times.Once);
            Assert.IsType<OkResult>(result);
        }
    }
}