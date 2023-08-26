using Microsoft.EntityFrameworkCore; //use DB context

namespace DemoDotNetAPI.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Product> Products { get; set; } //Dai dien cho 1 tap thuc the Products
        public DbSet<Type> Types { get; set; } //Dai dien cho 1 tap thuc the Types
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(or => or.OrderId);
                //e.Property(or => or.OrderDate).HasDefaultValueSql("GetUtcDate()");
                entity.Property(or => or.OrderDate).HasDefaultValueSql("getutcdate()");
                entity.Property(or => or.Recipient).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(e => new { e.OrderId, e.ProductId });

                entity.HasOne(or => or.Order)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");

                entity.HasOne(or => or.Product)
                .WithMany(e => e.OrderDetails)
                .HasForeignKey(e => e.ProductId)
                .HasConstraintName("FK_OrderDetail_Product");
            });
        }
    }
}
