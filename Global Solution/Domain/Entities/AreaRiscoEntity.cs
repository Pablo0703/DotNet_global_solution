using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_AREA_RISCO")]
    public class AreaRiscoEntity
    {
        [Key]
        [Column("ID_AREA")]
        public int ID_AREA { get; set; }

        [Required]
        [Column("NOME_AREA")]
        [MaxLength(100)]
        public string NOME_AREA { get; set; }

        [Column("LATITUDE")]
        public decimal? LATITUDE { get; set; } 

        [Column("LONGITUDE")]
        public decimal? LONGITUDE { get; set; } 

        [Column("NIVEL_NORMAL_ESTACAO_SECA")]
        public decimal? NIVEL_NORMAL_ESTACAO_SECA { get; set; } 

        [Column("NIVEL_NORMAL_ESTACAO_CHUVA")]
        public decimal? NIVEL_NORMAL_ESTACAO_CHUVA { get; set; }

        [Required]
        [Column("NIVEL_ALERTA_PREVENTIVO")]
        public decimal NIVEL_ALERTA_PREVENTIVO { get; set; }

        [Required]
        [Column("NIVEL_ALERTA_EMERGENCIA")]
        public decimal NIVEL_ALERTA_EMERGENCIA { get; set; }

        [Column("NIVEL_EVACUACAO")]
        public decimal? NIVEL_EVACUACAO { get; set; }

        [Column("AREA_ALAGADA_ALERTA")]
        public decimal? AREA_ALAGADA_ALERTA { get; set; } 

        [Column("AREA_ALAGADA_EMERGENCIA")]
        public decimal? AREA_ALAGADA_EMERGENCIA { get; set; }

        [Column("METODO_MEDICAO_NIVEL")]
        [MaxLength(50)]
        public string? METODO_MEDICAO_NIVEL { get; set; }

        [Column("METODO_MEDICAO_EXTENSAO")]
        [MaxLength(50)]
        public string? METODO_MEDICAO_EXTENSAO { get; set; }

        [Column("FONTE_DADOS")]
        [MaxLength(100)]
        public string? FONTE_DADOS { get; set; }

        [Column("ULTIMA_ATUALIZACAO")]
        public DateTime? ULTIMA_ATUALIZACAO { get; set; }

        [Column("RESPONSAVEL_ATUALIZACAO")]
        [MaxLength(50)]
        public string? RESPONSAVEL_ATUALIZACAO { get; set; }

        [Column("DESCRICAO")]
        [MaxLength(500)]
        public string? DESCRICAO { get; set; }

        // Relacionamentos
        public virtual ICollection<SensorEntity> SENSORES { get; set; }
        public virtual ICollection<AlertaEntity> ALERTAS { get; set; }
        public virtual ICollection<InscricaoAlertaEntity> INSCRICOES { get; set; }
    }
}
