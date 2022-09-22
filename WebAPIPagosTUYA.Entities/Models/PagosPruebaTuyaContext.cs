using Microsoft.EntityFrameworkCore;

#nullable disable

namespace WebAPIPagosTUYA.Entities.Models
{
    public partial class PagosPruebaTuyaContext<T> : DbContext where T : DbContext
    {
        public PagosPruebaTuyaContext(DbContextOptions<T> options) : base(options)
        {
        }

        public virtual DbSet<DetallesFactura> DetallesFacturas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<DetallesFactura>(entity =>
            {
                entity.HasKey(e => e.IDDetalleFactura);

                entity.Property(e => e.IDDetalleFactura).HasColumnName("IDDetalleFactura");

                entity.Property(e => e.IDFactura).HasColumnName("IDFactura");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(6, 0)");

                entity.Property(e => e.Total).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.IDFacturaNavigation)
                    .WithMany(p => p.DetallesFacturas)
                    .HasForeignKey(d => d.IDFactura)
                    .HasConstraintName("FK_DetallesFacturas_Facturas");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IDFactura);

                entity.Property(e => e.IDFactura).HasColumnName("IDFactura");

                entity.Property(e => e.NombreUsuario)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NroDocumento)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.NroFactura)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IDPedido);

                entity.Property(e => e.IDPedido).HasColumnName("IDPedido");

                entity.Property(e => e.Barrio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.IDFactura).HasColumnName("IDFactura");

                entity.Property(e => e.NroPedido)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDFacturaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IDFactura)
                    .HasConstraintName("FK_Pedidos_Facturas");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
