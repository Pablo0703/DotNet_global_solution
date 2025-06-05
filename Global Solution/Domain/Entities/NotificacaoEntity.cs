using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_NOTIFICACAO")]
    public class NotificacaoEntity
    {
        [Key]
        [Column("ID_NOTIFICACAO")]
        public int ID_NOTIFICACAO { get; set; }

        [Required]
        [Column("ID_ALERTA")]
        public int ID_ALERTA { get; set; }

        [Required]
        [Column("ID_USUARIO")]
        public int ID_USUARIO { get; set; }

        [Required]
        [Column("TIMESTAMP_ENVIO")]
        public DateTime TIMESTAMP_ENVIO { get; set; }

        [Required]
        [Column("CANAL_ENVIO")]
        [MaxLength(10)]
        public string CANAL_ENVIO { get; set; }

        [Column("STATUS_ENVIO")]
        [MaxLength(10)]
        public string STATUS_ENVIO { get; set; }

        [ForeignKey("ID_USUARIO")]
        public virtual UsuarioEntity USUARIO { get; set; }

        [ForeignKey("ID_ALERTA")]
        public virtual AlertaEntity ALERTA { get; set; }
    }
}
