using System;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BL
{
    public partial class StockMarketDbContext : IdentityDbContext<ApplicationUser>
    {
        public StockMarketDbContext()
        {
        }

        public StockMarketDbContext(DbContextOptions<StockMarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbRequest> TbRequests { get; set; }
        public virtual DbSet<TbSetting> TbSettings { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-ABVI0A5;Database=StockMarketDb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TbRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.Property(e => e.RequestId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfExpiry).HasColumnType("datetime");

                entity.Property(e => e.DateOfRequest).HasColumnType("datetime");

                entity.Property(e => e.DateofAction).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(200);

                entity.Property(e => e.SubscriptionPeriod).HasMaxLength(200);

                entity.Property(e => e.SubscriptionType).HasMaxLength(200);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(200);
            });

            modelBuilder.Entity<TbSetting>(entity =>
            {
                entity.HasKey(e => e.SubTrialFee);

                entity.ToTable("TbSetting");

                entity.Property(e => e.SubTrialFee).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BiancePayId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.PdfStrategyFee)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.QrCodeFile).HasMaxLength(200);

                entity.Property(e => e.SettingId)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.StrategyFile).HasMaxLength(200);

                entity.Property(e => e.SubProMonthlyFee)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.SubProWeeklyFee)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
