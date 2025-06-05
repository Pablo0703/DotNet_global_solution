using Global_Solution.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Global_Solution.Infrastructure.Data.AppData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AlertaEntity> ALERTA { get; set; }
        public DbSet<AreaRiscoEntity> AREA_RISCO { get; set; }
        public DbSet<SensorEntity> SENSOR { get; set; }
        public DbSet<LeituraSensorEntity> LEITURA_SENSOR { get; set; }
        public DbSet<UsuarioEntity> USUARIO { get; set; }
        public DbSet<InscricaoAlertaEntity> INSCRICAO_ALERTA { get; set; }
        public DbSet<NotificacaoEntity> NOTIFICACAO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
