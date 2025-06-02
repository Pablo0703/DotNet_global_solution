using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_ALERTA")]
    public class AlertaEntity
    {
        [Key]
        [Column("ID_ALERTA")]
        public int ID_ALERTA { get; set; }

        [Required]
        [Column("ID_AREA")]
        public int ID_AREA { get; set; }

        [Required]
        [Column("ID_LEITURA_GATILHO")]
        public int ID_LEITURA_GATILHO { get; set; }

        [Required]
        [Column("TIMESTAMP_ALERTA", TypeName = "timestamp")]
        public DateTime TIMESTAMP_ALERTA { get; set; }

        [Required]
        [Column("TIPO_ALERTA")]
        [MaxLength(20)]
        public string TIPO_ALERTA { get; set; }

        [Required]
        [Column("MENSAGEM_ALERTA")]
        [MaxLength(500)]
        public string MENSAGEM_ALERTA { get; set; }

        [Column("STATUS_ALERTA")]
        [MaxLength(10)]
        public string? STATUS_ALERTA { get; set; } // Nullable no banco

        // Navegação
        [ForeignKey("ID_AREA")]
        public virtual AreaRiscoEntity AREA_RISCO { get; set; }

        [ForeignKey("ID_LEITURA_GATILHO")]
        public virtual LeituraSensorEntity LEITURA_GATILHO { get; set; }
    }
}
