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

        // 3. Endpoint para SP_INCLUI_USUARIO
        [HttpPost("insert-usuario")]
        public async Task<IActionResult> InsertUsuario([FromBody] UsuarioRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NomeUsuario) || string.IsNullOrWhiteSpace(request.EmailUsuario))
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertUsuarioAsync(
                request.IdUsuario,
                request.NomeUsuario,
                request.EmailUsuario,
                request.SenhaUsuario,
                request.IdPontuacao
            );

            return Ok("Usuário inserido com sucesso.");
        }

        // 4. Endpoint para SP_INCLUI_DISPOSITIVO
        [HttpPost("insert-dispositivo")]
        public async Task<IActionResult> InsertDispositivo([FromBody] DispositivoRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.TipoDispositivo) || string.IsNullOrWhiteSpace(request.NomeDispositivo))
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertDispositivoAsync(
                request.IdDispositivo,
                request.TipoDispositivo,
                request.NomeDispositivo,
                request.StatusDispositivo,
                request.IdUsuario
            );

            return Ok("Dispositivo inserido com sucesso.");
        }

        // 5. Endpoint para SP_INCLUI_ENDERECO
        [HttpPost("insert-endereco")]
        public async Task<IActionResult> InsertEndereco([FromBody] EnderecoRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Logradouro) || string.IsNullOrWhiteSpace(request.Cidade))
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertEnderecoAsync(
                request.IdEndereco,
                request.Logradouro,
                request.Cep,
                request.Numero,
                request.Complemento,
                request.Bairro,
                request.Cidade,
                request.Estado,
                request.IdUsuario
            );

            return Ok("Endereço inserido com sucesso.");
        }

        // 6. Endpoint para SP_INCLUI_OBTER
        [HttpPost("insert-obter")]
        public async Task<IActionResult> InsertObter([FromBody] ObterRequest request)
        {
            if (request == null || request.IdDispositivo <= 0 || request.IdLeitura <= 0)
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertObterAsync(request.IdDispositivo, request.IdLeitura);

            return Ok("Relacionamento 'obter' inserido com sucesso.");
        }

        // 7. Endpoint para SP_INCLUI_TELEFONE
        [HttpPost("insert-telefone")]
        public async Task<IActionResult> InsertTelefone([FromBody] TelefoneRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.NumeroTelefone))
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertTelefoneAsync(
                request.IdTelefone,
                request.CodigoPais,
                request.Ddd,
                request.NumeroTelefone,
                request.IdUsuario
            );

            return Ok("Telefone inserido com sucesso.");
        }

        // 8. Endpoint para SP_INCLUI_ALERTA_OTIMIZACAO
        [HttpPost("insert-alerta-otimizacao")]
        public async Task<IActionResult> InsertAlertaOtimizacao([FromBody] AlertaOtimizacaoRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.TipoAlerta))
            {
                return BadRequest("Dados inválidos.");
            }

            await _energyDataService.InsertAlertaOtimizacaoAsync(
                request.IdAlerta,
                request.TipoAlerta,
                request.DataAlerta,
                request.Descricao,
                request.IdTelefone
            );

            return Ok("Alerta de otimização inserido com sucesso.");
        }
    }
}