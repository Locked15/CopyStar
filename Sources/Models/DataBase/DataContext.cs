using Microsoft.EntityFrameworkCore;

namespace CopyStar.Sources.Models.DataBase
{
    public partial class DataContext : DbContext
    {
        private static string? _connectionString;

        /// <summary>
        /// Static context, using to connect with database. <br />
        /// It doesn't expected be null, but if it does, throw exception.
        /// </summary>
        public static DataContext Instance { get; private set; }

        private DataContext()
        { }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Basket> Baskets { get; set; } = null!;
        public virtual DbSet<BasketItem> BasketItems { get; set; } = null!;
        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<CatalogBrand> CatalogBrands { get; set; } = null!;
        public virtual DbSet<CatalogItem> CatalogItems { get; set; } = null!;
        public virtual DbSet<CatalogType> CatalogTypes { get; set; } = null!;
        public virtual DbSet<FinalOrder> FinalOrders { get; set; } = null!;
        public virtual DbSet<ItemsInOrder> ItemsInOrders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;

        public static void InitializeConnection(string? connectionString)
        {
            _connectionString = connectionString;
            Instance = new DataContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString ?? throw new Exception("Connection string was 'NULL'."));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).HasMaxLength(64);

                entity.Property(e => e.Country).HasMaxLength(64);

                entity.Property(e => e.State).HasMaxLength(64);

                entity.Property(e => e.Street).HasMaxLength(64);

                entity.Property(e => e.ZipCode).HasMaxLength(128);
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.ToTable("Basket");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Baskets)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Basket__BuyerId__33D4B598");
            });

            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.ToTable("BasketItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Basket)
                    .WithMany(p => p.BasketItems)
                    .HasForeignKey(d => d.BasketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BasketIte__Baske__37A5467C");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.InverseItem)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BasketIte__ItemI__36B12243");
            });

            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.HasIndex(e => e.Login, "UQ__Buyer__5E55825B4A769634")
                    .IsUnique();

                entity.Property(e => e.Login).HasMaxLength(24);

                entity.HasOne(d => d.FavoritePayment)
                    .WithMany(p => p.Buyers)
                    .HasForeignKey(d => d.FavoritePaymentId)
                    .HasConstraintName("FK__Buyer__FavoriteP__286302EC");
            });

            modelBuilder.Entity<CatalogBrand>(entity =>
            {
                entity.ToTable("CatalogBrand");

                entity.Property(e => e.Brand).HasMaxLength(128);
            });

            modelBuilder.Entity<CatalogItem>(entity =>
            {
                entity.ToTable("CatalogItem");

                entity.Property(e => e.Image)
                    .HasMaxLength(512)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.CatalogItems)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__CatalogIt__Brand__300424B4");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CatalogItems)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK__CatalogIt__TypeI__2F10007B");
            });

            modelBuilder.Entity<CatalogType>(entity =>
            {
                entity.ToTable("CatalogType");

                entity.Property(e => e.Type).HasMaxLength(64);
            });

            modelBuilder.Entity<FinalOrder>(entity =>
            {
                entity.ToTable("FinalOrder");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.FinalOrders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FinalOrde__Addre__3D5E1FD2");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.FinalOrders)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FinalOrde__Buyer__3C69FB99");
            });

            modelBuilder.Entity<ItemsInOrder>(entity =>
            {
                entity.ToTable("ItemsInOrder");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemsInOrders)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemsInOr__ItemI__4316F928");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ItemsInOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItemsInOr__Order__440B1D61");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("OrderItem");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItem__ItemI__403A8C7D");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("PaymentMethod");

                entity.HasIndex(e => e.CardId, "UQ__PaymentM__55FECDAFAE408759")
                    .IsUnique();

                entity.Property(e => e.CardId).HasMaxLength(16);

                entity.Property(e => e.Method).HasMaxLength(32);

                entity.Property(e => e.SvcCode).HasMaxLength(3);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
