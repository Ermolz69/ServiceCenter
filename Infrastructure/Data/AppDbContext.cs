using Microsoft.EntityFrameworkCore;
using ServiceCenter.Domain.Entities;

namespace ServiceCenter.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<ServiceRequest> ServiceRequests => Set<ServiceRequest>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ------------------ Product ------------------
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasMaxLength(5000)   
                      .IsRequired();

                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)");

                entity.Property(e => e.PhotoBase64)
                      .IsRequired();

                entity.Property(e => e.Condition)
                      .HasConversion<string>()
                      .IsRequired();

                // Если хотите, можно настроить значение по умолчанию для CreatedAt
                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");
            });

            // ------------------ Order ------------------
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CustomerName)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.ContactPhone)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.DeliveryAddress)
                      .HasMaxLength(200)
                      .IsRequired();

                entity.Property(e => e.Comments)
                      .HasMaxLength(1000);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.HasMany(o => o.OrderItems)
                      .WithOne()
                      .HasForeignKey(nameof(OrderItem.OrderId))
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // ------------------ OrderItem ------------------
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Quantity)
                      .IsRequired();

                entity.Property(e => e.Price)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();

                entity.HasOne(e => e.Product)
                      .WithMany()
                      .HasForeignKey(e => e.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // ------------------ ServiceRequest ------------------
            modelBuilder.Entity<ServiceRequest>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.Phone)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(e => e.Email)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.DeviceType)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.Property(e => e.ProblemDescription)
                      .HasMaxLength(5000);

                entity.Property(e => e.CreatedAt)
                      .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}
