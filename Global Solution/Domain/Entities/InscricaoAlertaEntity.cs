using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_INSCRICAO_ALERTA")]
    public class InscricaoAlertaEntity
    {
        [Key]
        [Column("ID_INSCRICAO")]
        public int ID_INSCRICAO { get; set; }

        [Required]
        [Column("ID_USUARIO")]
        public int ID_USUARIO { get; set; }

        [Required]
        [Column("ID_AREA")]
        public int ID_AREA { get; set; }

        [Column("RECEBER_EMAIL")]
        public int RECEBER_EMAIL { get; set; }

        [Column("RECEBER_SMS")]
        public int RECEBER_SMS { get; set; }

        [Column("RECEBER_PUSH")]
        public int RECEBER_PUSH { get; set; }

        [Required]
        [Column("TIMESTAMP_INSCRICAO")]
        public DateTime TIMESTAMP_INSCRICAO { get; set; }

        [ForeignKey("ID_USUARIO")]
        public virtual UsuarioEntity USUARIO { get; set; }

        [ForeignKey("ID_AREA")]
        public virtual AreaRiscoEntity AREA_RISCO { get; set; }
    }
}
