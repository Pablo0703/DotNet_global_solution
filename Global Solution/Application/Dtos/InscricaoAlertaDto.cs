using System;

namespace Global_Solution.Application.Dtos
{
    public class InscricaoAlertaDto
    {
        public int ID_INSCRICAO { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_AREA { get; set; }
        public DateTime TIMESTAMP_INSCRICAO { get; set; }
        public bool RECEBER_EMAIL { get; set; }
        public bool RECEBER_SMS { get; set; }
        public bool RECEBER_PUSH { get; set; }
    }
}