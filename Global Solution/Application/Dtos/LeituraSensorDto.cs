using System;

namespace Global_Solution.Application.Dtos
{

        public class LeituraSensorDto
        {
            public int ID_LEITURA { get; set; }
            public string ID_SENSOR { get; set; }
            public DateTime TIMESTAMP_LEITURA { get; set; }
            public decimal VALOR_LEITURA { get; set; }
            public string UNIDADE_MEDIDA { get; set; }
        }
}