using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_LEITURA_SENSOR")]
    public class LeituraSensorEntity
    {
        [Key]
        [Column("ID_LEITURA")]
        public int ID_LEITURA { get; set; }

        [Required]
        [Column("ID_SENSOR")]
        [MaxLength(50)]
        public string ID_SENSOR { get; set; }

        [Required]
        [Column("TIMESTAMP_LEITURA")]
        public DateTime TIMESTAMP_LEITURA { get; set; }

        [Required]
        [Column("VALOR_LEITURA")]
        public decimal VALOR_LEITURA { get; set; }

        [Required]
        [Column("UNIDADE_MEDIDA")]
        [MaxLength(10)]
        public string UNIDADE_MEDIDA { get; set; }

        [ForeignKey("ID_SENSOR")]
        public virtual SensorEntity SENSOR { get; set; }
    }
}
