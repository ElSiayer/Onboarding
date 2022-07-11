using Microsoft.EntityFrameworkCore;
using creditoautomotriz.Entity.Models;

namespace creditoautomotriz.Repository.Context
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; } = null!;
        public virtual DbSet<Ejecutivo> Ejecutivo { get; set; } = null!;
        public virtual DbSet<Patio> Patio { get; set; } = null!;
        public virtual DbSet<Marca> Marca { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculo { get; set; } = null!;
        public virtual DbSet<Credito> Credito { get; set; } = null!;
        public virtual DbSet<EstadoCredito> EstadoCredito { get; set; } = null!;
        public virtual DbSet<ClientePatio> ClientePatio { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientePatio>()
                .HasKey(c => new { c.ClienteId, c.PatioId });
        }


    }
}
