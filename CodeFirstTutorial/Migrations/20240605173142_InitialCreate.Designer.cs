﻿// <auto-generated />
using CodeFirstTutorial.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstTutorial.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240605173142_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirstTutorial.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("FK_role");

                    b.HasKey("AccountId");

                    b.HasIndex("RoleId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Email = "j@k.com",
                            FirstName = "Jan",
                            LastName = "Kowalski",
                            Phone = "999888777",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_category");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Ściąga"
                        });
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("weight");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("width");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Depth = 0.0m,
                            Height = 0.0m,
                            Name = "Ściągi na egzamin z APBD",
                            Weight = 0.0m,
                            Width = 0.0m
                        });
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("FK_category");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductsCategories");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1
                        });
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.ShoppingCart", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("FK_account");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.HasKey("AccountId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ShoppingCarts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            ProductId = 1,
                            Amount = 1
                        });
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Account", b =>
                {
                    b.HasOne("CodeFirstTutorial.Models.Role", "Role")
                        .WithMany("Account")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.ProductCategory", b =>
                {
                    b.HasOne("CodeFirstTutorial.Models.Category", "Category")
                        .WithMany("ProductCategory")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstTutorial.Models.Product", "Product")
                        .WithMany("ProductCategory")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.ShoppingCart", b =>
                {
                    b.HasOne("CodeFirstTutorial.Models.Account", "Account")
                        .WithMany("ShoppingCart")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeFirstTutorial.Models.Product", "Product")
                        .WithMany("ShoppingCart")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Account", b =>
                {
                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Category", b =>
                {
                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Product", b =>
                {
                    b.Navigation("ProductCategory");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("CodeFirstTutorial.Models.Role", b =>
                {
                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
