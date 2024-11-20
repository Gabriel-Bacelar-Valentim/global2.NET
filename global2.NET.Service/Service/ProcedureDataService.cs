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
                "BEGIN SP_INCLUI_LEITURA_ENERGIA(:P_ID_LEIT, :P_CONSUMO, :P_PRODUCAO_ENERGIA, :P_DATA_LEITURA); END;",
                new OracleParameter("P_ID_LEIT", OracleDbType.Int32) { Value = idLeitura },
                new OracleParameter("P_CONSUMO", OracleDbType.NVarchar2) { Value = consumo.ToString("F2") },
                new OracleParameter("P_PRODUCAO_ENERGIA", OracleDbType.NVarchar2) { Value = producaoEnergia.ToString("F2") },
                new OracleParameter("P_DATA_LEITURA", OracleDbType.TimeStamp) { Value = dataLeitura }
            );
        }


        public async Task InsertIncentivoPontuacaoAsync(int idPontuacao, int pontosAdquiridos, int metaAlcancada, DateTime dataPontuacao)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "BEGIN SP_INCLUI_INCENTIVO_PONTUACAO(:P_IDPONT, :P_PONTOSADQUIRIDOS, :P_METALCANCADA, :P_DATAPONTUACAO); END;",
                new OracleParameter("P_IDPONT", OracleDbType.Int32) { Value = idPontuacao },
                new OracleParameter("P_PONTOSADQUIRIDOS", OracleDbType.Int32) { Value = pontosAdquiridos },
                new OracleParameter("P_METALCANCADA", OracleDbType.Int32) { Value = metaAlcancada },
                new OracleParameter("P_DATAPONTUACAO", OracleDbType.TimeStamp) { Value = dataPontuacao }
            );
        }
    }
}