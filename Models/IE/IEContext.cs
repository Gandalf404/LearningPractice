using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LearningPractice_IE_.Models.IE
{
    public partial class IEContext : DbContext
    {
        public IEContext()
        {
        }

        public IEContext(DbContextOptions<IEContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Error> Errors { get; set; } = null!;
        public virtual DbSet<IncomeAndExpense> IncomeAndExpenses { get; set; } = null!;
        public virtual DbSet<IndividualEntrepreneur> IndividualEntrepreneurs { get; set; } = null!;
        public virtual DbSet<Version> Versions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=localhost;Database=IE;Username=postgres;Password=123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Error>(entity =>
            {
                entity.ToTable("Error");

                entity.Property(e => e.ErrorId).HasColumnName("ErrorID");

                entity.Property(e => e.ErrorDescription).HasMaxLength(200);

                entity.Property(e => e.ErrorName).HasMaxLength(50);

                entity.Property(e => e.ErrorStatus).HasMaxLength(50);
            });

            modelBuilder.Entity<IncomeAndExpense>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Expense).HasColumnType("money");

                entity.Property(e => e.Incomes).HasColumnType("money");

                entity.Property(e => e.OperationDescription).HasMaxLength(200);

                entity.Property(e => e.OriginalDocumentDate).HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<IndividualEntrepreneur>(entity =>
            {
                entity.HasKey(e => e.EntrepreneurId)
                    .HasName("IndividualEntrepreneur_pkey");

                entity.ToTable("IndividualEntrepreneur");

                entity.Property(e => e.EntrepreneurId).HasColumnName("EntrepreneurID");

                entity.Property(e => e.EntrepreneurAccountBank).HasMaxLength(50);

                entity.Property(e => e.EntrepreneurAddress).HasMaxLength(150);

                entity.Property(e => e.EntrepreneurItn).HasColumnName("EntrepreneurITN");

                entity.Property(e => e.EntrepreneurLogin).HasMaxLength(20);

                entity.Property(e => e.EntrepreneurName).HasMaxLength(30);

                entity.Property(e => e.EntrepreneurPassword).HasMaxLength(20);

                entity.Property(e => e.EntrepreneurPatronymic).HasMaxLength(30);

                entity.Property(e => e.EntrepreneurSurname).HasMaxLength(30);
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("Version");

                entity.Property(e => e.VersionId).HasColumnName("VersionID");

                entity.Property(e => e.Version1)
                    .HasMaxLength(7)
                    .HasColumnName("Version");

                entity.Property(e => e.VersionUploadDate).HasDefaultValueSql("now()");

                entity.Property(e => e.VersionUrl)
                    .HasMaxLength(200)
                    .HasColumnName("VersionURL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
