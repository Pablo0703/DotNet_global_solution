using System;

namespace Global_Solution.Application.Dtos
{
    public class AreaRiscoDto
    {
        public int ID_AREA { get; set; }
        public string NOME_AREA { get; set; }
        public decimal? LATITUDE { get; set; }
        public decimal? LONGITUDE { get; set; }
        public decimal? NIVEL_NORMAL_ESTACAO_SECA { get; set; }
        public decimal? NIVEL_NORMAL_ESTACAO_CHUVA { get; set; }
        public decimal NIVEL_ALERTA_PREVENTIVO { get; set; }
        public decimal NIVEL_ALERTA_EMERGENCIA { get; set; }
        public decimal? NIVEL_EVACUACAO { get; set; }
        public decimal? AREA_ALAGADA_ALERTA { get; set; }
        public decimal? AREA_ALAGADA_EMERGENCIA { get; set; }
        public string METODO_MEDICAO_NIVEL { get; set; }
        public string METODO_MEDICAO_EXTENSAO { get; set; }
        public string FONTE_DADOS { get; set; }
        public DateTime? ULTIMA_ATUALIZACAO { get; set; }
        public string RESPONSAVEL_ATUALIZACAO { get; set; }
        public string DESCRICAO { get; set; }
    }
}