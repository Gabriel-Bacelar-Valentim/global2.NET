using global2.NET.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredictionController : ControllerBase
    {
        private readonly EnergyPredictionService _predictionService;

        public PredictionController(EnergyPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        [HttpPost("predict")]
        public ActionResult PredictConsumption([FromQuery] float producaoEnergia, [FromQuery] int dataLeitura)
        {
            if (producaoEnergia <= 0)
            {
                return BadRequest("Produção de energia deve ser maior que zero.");
            }

            if (dataLeitura <= 0 || dataLeitura < 1900 || dataLeitura > DateTime.Now.Year)
            {
                return BadRequest("Ano inválido. Certifique-se de que o ano está entre 1900 e o ano atual.");
            }

            float predictedConsumption = _predictionService.PredictConsumption(producaoEnergia, dataLeitura);

            return Ok(new
            {
                ProducaoEnergia = producaoEnergia,
                DataLeitura = dataLeitura,
                ConsumoPrevisto = predictedConsumption
            });
        }
    }
}