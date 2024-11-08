using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TextilesGeomar.API.Models;

namespace TextilesGeomar.API.Data;

public partial class TextilesGeomarDBContext : DbContext
{
    public TextilesGeomarDBContext()
    {
    }

    public TextilesGeomarDBContext(DbContextOptions<TextilesGeomarDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Institution> Institutions { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Uniform> Uniforms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=textilesgeomar-db; Database=textilesGeomar; User Id=sa; Password=Textiles2024; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A24DE246E20");

            entity.ToTable("Client");

            entity.HasIndex(e => e.InstitutionId, "IX_Client_InstitutionId");

            entity.HasIndex(e => e.Email, "UQ__Client__A9D10534E2786F85").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Clients)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Client__Institut__6477ECF3");
        });

        modelBuilder.Entity<Institution>(entity =>
        {
            entity.HasKey(e => e.InstitutionId).HasName("PK__Institut__8DF6B6ADC3CEA9D7");

            entity.ToTable("Institution");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Item__727E838B8F7A9E1F");

            entity.ToTable("Item");

            entity.HasIndex(e => e.InstitutionId, "IX_Item_InstitutionId");

            entity.HasIndex(e => e.StatusId, "IX_Item_StatusId");

            entity.HasIndex(e => e.UniformId, "IX_Item_UniformId");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FabricType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size).HasMaxLength(50);

            entity.HasOne(d => d.Institution).WithMany(p => p.Items)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Item__Institutio__6D0D32F4");

            entity.HasOne(d => d.Status).WithMany(p => p.Items)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Item__StatusId__6C190EBB");

            entity.HasOne(d => d.Uniform).WithMany(p => p.Items)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__Item__UniformId__6B24EA82");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A6E36D27F");

            entity.ToTable("Role");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C3FFBEE5AE6A");

            entity.ToTable("Sale");

            entity.HasIndex(e => e.ClientId, "IX_Sale_ClientId");

            entity.HasIndex(e => e.InstitutionId, "IX_Sale_InstitutionId");

            entity.HasIndex(e => e.ItemId, "IX_Sale_ItemId");

            entity.HasIndex(e => e.StatusId, "IX_Sale_StatusId");

            entity.HasIndex(e => e.UniformId, "IX_Sale_UniformId");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FinishedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Client).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__ClientId__72C60C4A");

            entity.HasOne(d => d.Institution).WithMany(p => p.Sales)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Sale__Institutio__73BA3083");

            entity.HasOne(d => d.Item).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__Sale__ItemId__70DDC3D8");

            entity.HasOne(d => d.Status).WithMany(p => p.Sales)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__StatusId__74AE54BC");

            entity.HasOne(d => d.Uniform).WithMany(p => p.Sales)
                .HasForeignKey(d => d.UniformId)
                .HasConstraintName("FK__Sale__UniformId__71D1E811");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Status__C8EE20631418863F");

            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Uniform>(entity =>
        {
            entity.HasKey(e => e.UniformId).HasName("PK__Uniform__FF513A502E087F2D");

            entity.ToTable("Uniform");

            entity.HasIndex(e => e.InstitutionId, "IX_Uniform_InstitutionId");

            entity.HasIndex(e => e.StatusId, "IX_Uniform_StatusId");

            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Institution).WithMany(p => p.Uniforms)
                .HasForeignKey(d => d.InstitutionId)
                .HasConstraintName("FK__Uniform__Institu__6754599E");

            entity.HasOne(d => d.Status).WithMany(p => p.Uniforms)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Uniform__StatusI__68487DD7");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CEC168045");

            entity.ToTable("User");

            entity.HasIndex(e => e.RoleId, "IX_User_RoleId");

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534567DD2A7").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleId__60A75C0F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
