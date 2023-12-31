﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyBoxWebsite.Data;

#nullable disable

namespace MoneyBoxWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230919143851_PriceUpdate")]
    partial class PriceUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoneyBoxWebsite.Models.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<bool>("AccountEnabled")
                        .HasColumnType("bit")
                        .HasColumnName("enabled");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("address");

                    b.Property<Guid>("CurrentRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentTheme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("current_theme");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("first_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("CurrentRoleId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeliveringAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("delivering_address");

                    b.Property<Guid>("OrderStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("OrderTotalSum")
                        .HasColumnType("real")
                        .HasColumnName("order_total_sum");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reference");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("reservation_date");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("color");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<float>("Height")
                        .HasColumnType("real")
                        .HasColumnName("height");

                    b.Property<string>("ImageFilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("image_file_path");

                    b.Property<float>("Length")
                        .HasColumnType("real")
                        .HasColumnName("length");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("manufacturer");

                    b.Property<int>("MoneyCapacity")
                        .HasColumnType("int")
                        .HasColumnName("money_capacity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<float>("Price")
                        .HasColumnType("real")
                        .HasColumnName("price");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reference");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit")
                        .HasColumnName("visibility");

                    b.Property<float>("Weigth")
                        .HasColumnType("real")
                        .HasColumnName("weight");

                    b.Property<float>("Width")
                        .HasColumnType("real")
                        .HasColumnName("width");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.ProductGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("ProductGroups");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.ProductOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("LinkedOrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LinkedProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<float>("SellPrice")
                        .HasColumnType("real")
                        .HasColumnName("sell_price");

                    b.HasKey("Id");

                    b.HasIndex("LinkedOrderId");

                    b.HasIndex("LinkedProductId");

                    b.ToTable("ProductOrder");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsValidate")
                        .HasColumnType("bit")
                        .HasColumnName("validate");

                    b.Property<Guid>("LinkedProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LinkedProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ProductProductGroup", b =>
                {
                    b.Property<Guid>("GroupedProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductGroupsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GroupedProductsId", "ProductGroupsId");

                    b.HasIndex("ProductGroupsId");

                    b.ToTable("ProductProductGroup");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Client", b =>
                {
                    b.HasOne("MoneyBoxWebsite.Models.Role", "CurrentRole")
                        .WithMany("Users")
                        .HasForeignKey("CurrentRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentRole");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Order", b =>
                {
                    b.HasOne("MoneyBoxWebsite.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyBoxWebsite.Models.OrderStatus", "OrderStatus")
                        .WithMany("OrdersWithStatus")
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.ProductOrder", b =>
                {
                    b.HasOne("MoneyBoxWebsite.Models.Order", "LinkedOrder")
                        .WithMany("OrderedProducts")
                        .HasForeignKey("LinkedOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyBoxWebsite.Models.Product", "LinkedProduct")
                        .WithMany("ProductOrders")
                        .HasForeignKey("LinkedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LinkedOrder");

                    b.Navigation("LinkedProduct");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Review", b =>
                {
                    b.HasOne("MoneyBoxWebsite.Models.Client", "Creator")
                        .WithMany("Reviews")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyBoxWebsite.Models.Product", "LinkedProduct")
                        .WithMany("Reviews")
                        .HasForeignKey("LinkedProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("LinkedProduct");
                });

            modelBuilder.Entity("ProductProductGroup", b =>
                {
                    b.HasOne("MoneyBoxWebsite.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("GroupedProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MoneyBoxWebsite.Models.ProductGroup", null)
                        .WithMany()
                        .HasForeignKey("ProductGroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Client", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Order", b =>
                {
                    b.Navigation("OrderedProducts");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.OrderStatus", b =>
                {
                    b.Navigation("OrdersWithStatus");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Product", b =>
                {
                    b.Navigation("ProductOrders");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("MoneyBoxWebsite.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
