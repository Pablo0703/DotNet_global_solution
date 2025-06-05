using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_SENSOR")]
    public class SensorEntity
    {
        [Key]
        [Column("ID_SENSOR")]
        [MaxLength(50)]
        public string ID_SENSOR { get; set; }

        [Required]
        [Column("ID_AREA")]
        public int ID_AREA { get; set; }

        [Required]
        [Column("TIPO_SENSOR")]
        [MaxLength(20)]
        public string TIPO_SENSOR { get; set; }

        [Required]
        [Column("MODELO")]
        [MaxLength(50)]
        public string MODELO { get; set; }

        [Required]
        [Column("DATA_INSTALACAO")]
        public DateTime DATA_INSTALACAO { get; set; }

        [Column("ULTIMA_MANUTENCAO")]
        public DateTime? ULTIMA_MANUTENCAO { get; set; }

        [Column("STATUS_SENSOR")]
        [MaxLength(15)]
        public string STATUS_SENSOR { get; set; }

        [ForeignKey("ID_AREA")]
        public AreaRiscoEntity AREA_RISCO { get; set; }

        public ICollection<LeituraSensorEntity> LEITURAS { get; set; }
    }
}
