using global2.NET.Database;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;

namespace global2.NET.Service.Services
{
    public class ProcedureDataService
    {
        private readonly FIAPDbContext _context;

        public ProcedureDataService(FIAPDbContext context)
        {
            _context = context;
        }

        // Procedures:
        public async Task InsertLeituraEnergiaAsync(int idLeitura, DateTime dataLeitura, float consumo, float producaoEnergia)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_LEITURA_ENERGIA(:P_ID_LEIT, :P_DATA_LEITURA, :P_CONSUMO, :P_PRODUCAO_ENERGIA); END;",
                new OracleParameter("P_ID_LEIT", OracleDbType.Int32) { Value = idLeitura },
                new OracleParameter("P_DATA_LEITURA", OracleDbType.Date) { Value = dataLeitura },
                new OracleParameter("P_CONSUMO", OracleDbType.Varchar2) { Value = consumo.ToString("F2") },
                new OracleParameter("P_PRODUCAO_ENERGIA", OracleDbType.Varchar2) { Value = producaoEnergia.ToString("F2") }
            );
        }


        public async Task InsertIncentivoPontuacaoAsync(int idPontuacao, int pontosAdquiridos, bool metaAlcancada, DateTime dataPontuacao)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_INCENTIVO_PONTUACAO(:P_IDPONT, :P_PONTOSADQUIRIDOS, :P_METALCANCADA, :P_DATAPONTUACAO); END;",
                new OracleParameter("P_IDPONT", idPontuacao),
                new OracleParameter("P_PONTOSADQUIRIDOS", pontosAdquiridos),
                new OracleParameter("P_METALCANCADA", metaAlcancada),
                new OracleParameter("P_DATAPONTUACAO", dataPontuacao)
            );
        }

        public async Task InsertUsuarioAsync(int idUsuario, string nomeUsuario, string emailUsuario, string senhaUsuario, int idPontuacao)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_USUARIO(:P_ID_USUA, :P_NOME_USUA, :P_EMAIL_USUA, :P_SENHA_USUA, :P_INCENTIVO_PONTUACAO_IDPONT); END;",
                new OracleParameter("P_ID_USUA", idUsuario),
                new OracleParameter("P_NOME_USUA", nomeUsuario),
                new OracleParameter("P_EMAIL_USUA", emailUsuario),
                new OracleParameter("P_SENHA_USUA", senhaUsuario),
                new OracleParameter("P_INCENTIVO_PONTUACAO_IDPONT", idPontuacao)
            );
        }

        public async Task InsertDispositivoAsync(int idDispositivo, string tipoDispositivo, string nomeDispositivo, bool statusDispositivo, int idUsuario)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_DISPOSITIVO(:P_ID_DISP, :P_TIPO_DISP, :P_NOME_DISP, :P_STATUS_DISP, :P_USUARIO_IDUSUA); END;",
                new OracleParameter("P_ID_DISP", idDispositivo),
                new OracleParameter("P_TIPO_DISP", tipoDispositivo),
                new OracleParameter("P_NOME_DISP", nomeDispositivo),
                new OracleParameter("P_STATUS_DISP", statusDispositivo),
                new OracleParameter("P_USUARIO_IDUSUA", idUsuario)
            );
        }

        public async Task InsertEnderecoAsync(int idEndereco, string logradouro, string cep, string numero, string complemento, string bairro, string cidade, string estado, int idUsuario)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_ENDERECO(:P_ID_ENDE, :P_LOGRADOURO, :P_CEP, :P_NUMERO, :P_COMPLEMENTO, :P_BAIRRO, :P_CIDADE, :P_ESTADO, :P_USUARIO_IDUSUA); END;",
                new OracleParameter("P_ID_ENDE", idEndereco),
                new OracleParameter("P_LOGRADOURO", logradouro),
                new OracleParameter("P_CEP", cep),
                new OracleParameter("P_NUMERO", numero),
                new OracleParameter("P_COMPLEMENTO", complemento),
                new OracleParameter("P_BAIRRO", bairro),
                new OracleParameter("P_CIDADE", cidade),
                new OracleParameter("P_ESTADO", estado),
                new OracleParameter("P_USUARIO_IDUSUA", idUsuario)
            );
        }

        public async Task InsertObterAsync(int idDispositivo, int idLeitura)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_OBTER(:P_DISPOSITIVO_IDDISP, :P_LEITURA_ENERGIA_IDLEIT); END;",
                new OracleParameter("P_DISPOSITIVO_IDDISP", idDispositivo),
                new OracleParameter("P_LEITURA_ENERGIA_IDLEIT", idLeitura)
            );
        }

        public async Task InsertTelefoneAsync(int idTelefone, string codigoPais, string ddd, string numeroTelefone, int idUsuario)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_TELEFONE(:P_ID_TELEF, :P_CODIGO_PAIS, :P_DDD, :P_NUMERO_TELEFONE, :P_USUARIO_IDUSUA); END;",
                new OracleParameter("P_ID_TELEF", idTelefone),
                new OracleParameter("P_CODIGO_PAIS", codigoPais),
                new OracleParameter("P_DDD", ddd),
                new OracleParameter("P_NUMERO_TELEFONE", numeroTelefone),
                new OracleParameter("P_USUARIO_IDUSUA", idUsuario)
            );
        }

        public async Task InsertAlertaOtimizacaoAsync(int idAlerta, string tipoAlerta, DateTime dataAlerta, string descricao, int idTelefone)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_ALERTA_OTIMIZACAO(:P_ID_ALER, :P_TIPO_ALERTA, :P_DATA_ALERTA, :P_DESCRICAO, :P_TELEFONE_IDTELEF); END;",
                new OracleParameter("P_ID_ALER", idAlerta),
                new OracleParameter("P_TIPO_ALERTA", tipoAlerta),
                new OracleParameter("P_DATA_ALERTA", dataAlerta),
                new OracleParameter("P_DESCRICAO", descricao),
                new OracleParameter("P_TELEFONE_IDTELEF", idTelefone)
            );
        }
    }
}