using System;

namespace Global_Solution.Application.Dtos
{
    public class NotificacaoDto
    {
        public int ID_NOTIFICACAO { get; set; }
        public int ID_ALERTA { get; set; }
        public int ID_USUARIO { get; set; }
        public DateTime TIMESTAMP_ENVIO { get; set; }
        public string CANAL_ENVIO { get; set; }
        public string STATUS_ENVIO { get; set; }
    }
}
