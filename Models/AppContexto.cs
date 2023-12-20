using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace API_Panificadora.Models
{
    public class AppContexto : DbContext

    {
        public AppContexto(DbContextOptions options) : base(options) { }

        public DbContext Instance => this;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModelView>()
                .HasKey(b => b.Id)
                .HasName("PrimaryKey_ClientID");
        }

        public DbSet<ClienteModelView> cliente { get; set; }
        public DbSet<UsuarioViewModel> usuario { get; set; }
    }
}
