﻿namespace global2.NET.Service.ServiceModel
{
    public class IncentivoPontuacaoRequest
    {
        public int IdPontuacao { get; set; }
        public int PontosAdquiridos { get; set; }
        public int MetaAlcancada { get; set; }
        public DateTime DataPontuacao { get; set; }
    }
}
