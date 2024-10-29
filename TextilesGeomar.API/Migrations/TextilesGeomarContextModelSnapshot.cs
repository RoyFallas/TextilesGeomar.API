﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TextilesGeomar.API.Data;

#nullable disable

namespace TextilesGeomar.API.Migrations
{
    [DbContext(typeof(TextilesGeomarDBContext))]
    partial class TextilesGeomarContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TextilesGeomar.API.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClientId")
                        .HasName("PK__Client__E67E1A24DE246E20");

                    b.HasIndex("InstitutionId");

                    b.HasIndex(new[] { "Email" }, "UQ__Client__A9D10534E2786F85")
                        .IsUnique();

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Institution", b =>
                {
                    b.Property<int>("InstitutionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstitutionId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstitutionId")
                        .HasName("PK__Institut__8DF6B6ADC3CEA9D7");

                    b.ToTable("Institution", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FabricType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Size")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UniformId")
                        .HasColumnType("int");

                    b.HasKey("ItemId")
                        .HasName("PK__Item__727E838B8F7A9E1F");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UniformId");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE1A6E36D27F");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("FinishedDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<int?>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UniformId")
                        .HasColumnType("int");

                    b.HasKey("SaleId")
                        .HasName("PK__Sale__1EE3C3FFBEE5AE6A");

                    b.HasIndex("ClientId");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("ItemId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UniformId");

                    b.ToTable("Sale", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StatusId")
                        .HasName("PK__Status__C8EE20631418863F");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Uniform", b =>
                {
                    b.Property<int>("UniformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UniformId"));

                    b.Property<int?>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("UniformId")
                        .HasName("PK__Uniform__FF513A502E087F2D");

                    b.HasIndex("InstitutionId");

                    b.HasIndex("StatusId");

                    b.ToTable("Uniform", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId")
                        .HasName("PK__User__1788CC4CEC168045");

                    b.HasIndex("RoleId");

                    b.HasIndex(new[] { "Email" }, "UQ__User__A9D10534567DD2A7")
                        .IsUnique();

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Client", b =>
                {
                    b.HasOne("TextilesGeomar.API.Models.Institution", "Institution")
                        .WithMany("Clients")
                        .HasForeignKey("InstitutionId")
                        .HasConstraintName("FK__Client__Institut__6477ECF3");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Item", b =>
                {
                    b.HasOne("TextilesGeomar.API.Models.Institution", "Institution")
                        .WithMany("Items")
                        .HasForeignKey("InstitutionId")
                        .HasConstraintName("FK__Item__Institutio__6D0D32F4");

                    b.HasOne("TextilesGeomar.API.Models.Status", "Status")
                        .WithMany("Items")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Item__StatusId__6C190EBB");

                    b.HasOne("TextilesGeomar.API.Models.Uniform", "Uniform")
                        .WithMany("Items")
                        .HasForeignKey("UniformId")
                        .HasConstraintName("FK__Item__UniformId__6B24EA82");

                    b.Navigation("Institution");

                    b.Navigation("Status");

                    b.Navigation("Uniform");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Sale", b =>
                {
                    b.HasOne("TextilesGeomar.API.Models.Client", "Client")
                        .WithMany("Sales")
                        .HasForeignKey("ClientId")
                        .IsRequired()
                        .HasConstraintName("FK__Sale__ClientId__72C60C4A");

                    b.HasOne("TextilesGeomar.API.Models.Institution", "Institution")
                        .WithMany("Sales")
                        .HasForeignKey("InstitutionId")
                        .HasConstraintName("FK__Sale__Institutio__73BA3083");

                    b.HasOne("TextilesGeomar.API.Models.Item", "Item")
                        .WithMany("Sales")
                        .HasForeignKey("ItemId")
                        .HasConstraintName("FK__Sale__ItemId__70DDC3D8");

                    b.HasOne("TextilesGeomar.API.Models.Status", "Status")
                        .WithMany("Sales")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Sale__StatusId__74AE54BC");

                    b.HasOne("TextilesGeomar.API.Models.Uniform", "Uniform")
                        .WithMany("Sales")
                        .HasForeignKey("UniformId")
                        .HasConstraintName("FK__Sale__UniformId__71D1E811");

                    b.Navigation("Client");

                    b.Navigation("Institution");

                    b.Navigation("Item");

                    b.Navigation("Status");

                    b.Navigation("Uniform");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Uniform", b =>
                {
                    b.HasOne("TextilesGeomar.API.Models.Institution", "Institution")
                        .WithMany("Uniforms")
                        .HasForeignKey("InstitutionId")
                        .HasConstraintName("FK__Uniform__Institu__6754599E");

                    b.HasOne("TextilesGeomar.API.Models.Status", "Status")
                        .WithMany("Uniforms")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Uniform__StatusI__68487DD7");

                    b.Navigation("Institution");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.User", b =>
                {
                    b.HasOne("TextilesGeomar.API.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK__User__RoleId__60A75C0F");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Client", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Institution", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Items");

                    b.Navigation("Sales");

                    b.Navigation("Uniforms");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Item", b =>
                {
                    b.Navigation("Sales");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Status", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Sales");

                    b.Navigation("Uniforms");
                });

            modelBuilder.Entity("TextilesGeomar.API.Models.Uniform", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
