using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningPractice_Launcher_.Models.ErrorReportDep
{
    public partial class ErrorReportDepContext : DbContext
    {
        public ErrorReportDepContext()
        {
        }

        public ErrorReportDepContext(DbContextOptions<ErrorReportDepContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Developer> Developers { get; set; } = null!;
        public virtual DbSet<Error> Errors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=ErrorReportDep;Username=postgres;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>(entity =>
            {
                entity.ToTable("Developer");

                entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");

                entity.Property(e => e.DeveloperLogin).HasMaxLength(20);

                entity.Property(e => e.DeveloperName).HasMaxLength(20);

                entity.Property(e => e.DeveloperPassword).HasMaxLength(20);

                entity.Property(e => e.DeveloperSurname).HasMaxLength(20);

                entity.Property(e => e.ErrorStatus).HasMaxLength(20);
            });

            modelBuilder.Entity<Error>(entity =>
            {
                entity.ToTable("Error");

                entity.Property(e => e.ErrorDescription).HasMaxLength(5000);

                entity.Property(e => e.ErrorStatus).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(11);

                entity.Property(e => e.VersionDownloadUrl)
                    .HasMaxLength(200)
                    .HasColumnName("VersionDownloadURL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
