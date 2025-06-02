using System;

namespace Global_Solution.Application.Dtos
{
    public class SensorDto
    {
        public string ID_SENSOR { get; set; }
        public int ID_AREA { get; set; }
        public string TIPO_SENSOR { get; set; }
        public string MODELO { get; set; }
        public DateTime DATA_INSTALACAO { get; set; }
        public DateTime? ULTIMA_MANUTENCAO { get; set; }
        public string STATUS_SENSOR { get; set; }
    }
}
