using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApiSolo.Models
{
    public partial class surebetdbContext : DbContext
    {
        public surebetdbContext()
        {
        }

        public surebetdbContext(DbContextOptions<surebetdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SiteDatum> SiteData { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblSite> TblSites { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }
        public virtual DbSet<TblUserSite> TblUserSites { get; set; }
        public virtual DbSet<TcpServerInfo> TcpServerInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=cyberspace;Database=surebetdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SiteDatum>(entity =>
            {
                entity.Property(e => e.AwayTeam).HasMaxLength(50);

                entity.Property(e => e.AwayWin).HasMaxLength(50);

                entity.Property(e => e.Day).HasMaxLength(50);

                entity.Property(e => e.Draw).HasMaxLength(50);

                entity.Property(e => e.HomeTeam).HasMaxLength(50);

                entity.Property(e => e.HomeWin).HasMaxLength(50);

                entity.Property(e => e.Site).HasMaxLength(50);

                entity.Property(e => e.Time).HasMaxLength(50);

                entity.HasOne(d => d.SiteNavigation)
                    .WithMany(p => p.SiteData)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_SiteData_TblSites");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("TblRole");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<TblSite>(entity =>
            {
                entity.HasKey(e => e.SiteId);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("TblUser");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UserUid).HasColumnName("UserUID");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.ToTable("TblUserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_TblUserRole_TblRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TblUserRole_TblUser");
            });

            modelBuilder.Entity<TblUserSite>(entity =>
            {
                entity.HasKey(e => e.UserSitesId);

                entity.HasOne(d => d.Site)
                    .WithMany(p => p.TblUserSites)
                    .HasForeignKey(d => d.SiteId)
                    .HasConstraintName("FK_TblUserSites_TblSites");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserSites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_TblUserSites_TblUser");
            });

            modelBuilder.Entity<TcpServerInfo>(entity =>
            {
                entity.ToTable("TcpServerInfo");

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .HasColumnName("ip");

                entity.Property(e => e.Port).HasColumnName("port");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
