using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Global_Solution.Domain.Entities
{
    [Table("SMAE_USUARIO")]
    public class UsuarioEntity
    {
        [Key]
        [Column("ID_USUARIO")]
        public int ID_USUARIO { get; set; }

        [Required]
        [Column("NOME_USUARIO")]
        [MaxLength(100)]
        public string NOME_USUARIO { get; set; }

        [Required]
        [Column("EMAIL")]
        [MaxLength(100)]
        public string EMAIL { get; set; }

        [Column("TELEFONE")]
        [MaxLength(20)]
        public string? TELEFONE { get; set; }

        [Required]
        [Column("TIPO_USUARIO")]
        [MaxLength(20)]
        public string TIPO_USUARIO { get; set; }

        [Required]
        [Column("SENHA_HASH")]
        [MaxLength(100)]
        public string SENHA_HASH { get; set; }

        [Required]
        [Column("DATA_CADASTRO")]
        public DateTime DATA_CADASTRO { get; set; }

        public ICollection<InscricaoAlertaEntity> INSCRICOES { get; set; }
        public ICollection<NotificacaoEntity> NOTIFICACOES { get; set; }
    }
}
