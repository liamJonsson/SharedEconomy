using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SharedEconomy.Data.Models;

public partial class SharedEconomyDbContext : DbContext
{
    public SharedEconomyDbContext()
    {
    }

    public SharedEconomyDbContext(DbContextOptions<SharedEconomyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<SubAccount> SubAccounts { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:sharedeconomy-sql-server.database.windows.net,1433;Initial Catalog=SharedEconomyDB;Persist Security Info=False;User ID=sqladmin;Password=durMix-kyhmaq-3qavcy;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07E14624E5");

            entity.ToTable("Account");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Profile).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.ProfileId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Account__Profile__71D1E811");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profile__3214EC07ED28078C");

            entity.ToTable("Profile");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<SubAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SubAccou__3214EC0711C4275D");

            entity.ToTable("SubAccount");

            entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany(p => p.SubAccounts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubAccoun__Accou__75A278F5");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3214EC0780F40FC0");

            entity.ToTable("Transaction");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Comment).HasMaxLength(255);
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.SubAccount).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.SubAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Transacti__SubAc__797309D9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
