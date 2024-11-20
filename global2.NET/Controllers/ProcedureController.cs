using global2.NET.Service.ServiceModel;
using global2.NET.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace global2.NET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcedureController : ControllerBase
    {
        private readonly ProcedureDataService _energyDataService;

        public ProcedureController(ProcedureDataService energyDataService)
        {
            _energyDataService = energyDataService;
        }

        // 1. Endpoint para SP_INCLUI_LEITURA_ENERGIA
        [HttpPost("insert-leitura-energia")]
        public async Task<IActionResult> InsertLeituraEnergia([FromBody] LeituraEnergiaRequest request)
        {
            if (request == null || request.Consumo <= 0 || request.ProducaoEnergia <= 0)
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertLeituraEnergiaAsync(
                request.IdLeitura,
                request.DataLeitura,
                request.Consumo,
                request.ProducaoEnergia
            );

            return Ok("Leitura de energia inserida com sucesso.");
        }

        // 2. Endpoint para SP_INCLUI_INCENTIVO_PONTUACAO
        [HttpPost("insert-incentivo-pontuacao")]
        public async Task<IActionResult> InsertIncentivoPontuacao([FromBody] IncentivoPontuacaoRequest request)
        {
            if (request == null || request.PontosAdquiridos <= 0 || request.DataPontuacao == default)
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertIncentivoPontuacaoAsync(
                request.IdPontuacao,
                request.PontosAdquiridos,
                request.MetaAlcancada,
                request.DataPontuacao
            );

            return Ok("Incentivo de pontuação inserido com sucesso.");
        }
    }
}