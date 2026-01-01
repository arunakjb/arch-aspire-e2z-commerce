using System;
using System.Collections.Generic;
using E2Z.DB.ORM.Models;
using Microsoft.EntityFrameworkCore;

namespace E2Z.DB.ORM.Context;

public partial class E2ZDbContext : DbContext
{
    public E2ZDbContext()
    {
    }

    public E2ZDbContext(DbContextOptions<E2ZDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartDetail> CartDetails { get; set; }

    public virtual DbSet<DeliveryDetail> DeliveryDetails { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<ReturnDetail> ReturnDetails { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<UserFavorite> UserFavorites { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<UserRecentActivity> UserRecentActivities { get; set; }

    public virtual DbSet<UserReview> UserReviews { get; set; }

    public virtual DbSet<UserReviewImage> UserReviewImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=E2ZDb;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartDetail>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__CartDeta__3214EC27DDE10626");

            entity.Property(e => e.IsBought).HasDefaultValue(false);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Product).WithMany(p => p.CartDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartDetails_Products");

            entity.HasOne(d => d.User).WithMany(p => p.CartDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartDetails_UserProfile");
        });

        modelBuilder.Entity<DeliveryDetail>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Delivery__3214EC27DB1EEAD3");

            entity.Property(e => e.IsCashOnDelivery).HasDefaultValue(false);
            entity.Property(e => e.IsDelivered).HasDefaultValue(false);
            entity.Property(e => e.ReturnProduct).HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.DeliveryDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DeliveryDetails_UserProfile");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Orders__3214EC2791F3A151");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_UserProfile");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Products__3214EC27A448B39E");

            entity.Property(e => e.CreationTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsReturnApplicable).HasDefaultValue(false);
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ProductI__3214EC273DBBE3C9");

            entity.Property(e => e.LastUpdated).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages).HasConstraintName("FK_ProductImages_Products");
        });

        modelBuilder.Entity<ReturnDetail>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__ReturnDe__3214EC27CCEEA6C1");

            entity.Property(e => e.IsCancelled).HasDefaultValue(false);

            entity.HasOne(d => d.Delivery).WithMany(p => p.ReturnDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnDetails_DeliveryDetails");

            entity.HasOne(d => d.Product).WithMany(p => p.ReturnDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnDetails_Products");

            entity.HasOne(d => d.User).WithMany(p => p.ReturnDetails)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReturnDetails_UserProfile");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__Transact__3214EC2762A6AEAE");

            entity.Property(e => e.IsTransactionSuccess).HasDefaultValue(true);
            entity.Property(e => e.TransactionTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_UserProfile");
        });

        modelBuilder.Entity<UserFavorite>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__UserFavo__3214EC277C15C50E");

            entity.Property(e => e.CreationTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Product).WithMany(p => p.UserFavorites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFavorites_Products");

            entity.HasOne(d => d.User).WithMany(p => p.UserFavorites)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserFavorites_UserProfile");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserProf__1788CC4C99E953F6");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreationTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsLoggedIn).HasDefaultValue(false);
        });

        modelBuilder.Entity<UserRecentActivity>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__UserRece__3214EC27602AF3F8");

            entity.Property(e => e.LastVisitedTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.VisitedOccurences).HasDefaultValue(1);

            entity.HasOne(d => d.ProductClickedNavigation).WithMany(p => p.UserRecentActivities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRecentActivity_Products");

            entity.HasOne(d => d.User).WithMany(p => p.UserRecentActivities)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRecentActivity_UserProfile");
        });

        modelBuilder.Entity<UserReview>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__UserRevi__3214EC279DED05E4");

            entity.HasOne(d => d.Product).WithMany(p => p.UserReviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserReviews_Products");

            entity.HasOne(d => d.User).WithMany(p => p.UserReviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserReviews_UserProfile");
        });

        modelBuilder.Entity<UserReviewImage>(entity =>
        {
            entity.HasKey(e => e.ID).HasName("PK__UserRevi__3214EC276F44E743");

            entity.HasOne(d => d.Review).WithMany(p => p.UserReviewImages).HasConstraintName("FK_UserReviewImages_UserReviews");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
