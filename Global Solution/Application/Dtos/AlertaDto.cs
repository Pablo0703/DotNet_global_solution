using System;

namespace Global_Solution.Application.Dtos
{
    public class AlertaDto
    {
        public int ID_ALERTA { get; set; }
        public int ID_AREA { get; set; }
        public int ID_LEITURA_GATILHO { get; set; }
        public DateTime TIMESTAMP_ALERTA { get; set; }
        public string TIPO_ALERTA { get; set; }
        public string MENSAGEM_ALERTA { get; set; }
        public string STATUS_ALERTA { get; set; }
    }
}

