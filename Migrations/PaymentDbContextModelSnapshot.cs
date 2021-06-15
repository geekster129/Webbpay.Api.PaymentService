﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Webbpay.Api.PaymentService.Adapters.Database;

namespace Webbpay.Api.PaymentService.Migrations
{
    [DbContext(typeof(PaymentDbContext))]
    partial class PaymentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.PaymentLink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PaymentLinkRef")
                        .HasColumnType("longtext");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Status");

                    b.HasIndex("Id", "StoreId")
                        .IsUnique();

                    b.ToTable("PaymentLink");
                });

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.PaymentTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ContactAddress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ContactCountry")
                        .HasMaxLength(3)
                        .HasColumnType("varchar(3)");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ContactMobileNo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("ContactPostcode")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("ContactState")
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PaymentChannel")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("PaymentChannelId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PaymentLinkId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PaymentMode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PaymentOrderNo")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PaymentRef1")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentRef2")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentRef3")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentRemarks")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentLinkId");

                    b.HasIndex("PaymentOrderNo")
                        .IsUnique();

                    b.ToTable("PaymentTransaction");
                });

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.TransactionEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("EventData")
                        .HasColumnType("longtext");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<Guid>("PaymentTransactionId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTransactionId");

                    b.ToTable("TransactionEvents");
                });

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.PaymentTransaction", b =>
                {
                    b.HasOne("Webbpay.Api.PaymentService.Entities.PaymentLink", "PaymentLink")
                        .WithMany("PaymentTransactions")
                        .HasForeignKey("PaymentLinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentLink");
                });

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.TransactionEvent", b =>
                {
                    b.HasOne("Webbpay.Api.PaymentService.Entities.PaymentTransaction", "Payment")
                        .WithMany("Events")
                        .HasForeignKey("PaymentTransactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.PaymentLink", b =>
                {
                    b.Navigation("PaymentTransactions");
                });

            modelBuilder.Entity("Webbpay.Api.PaymentService.Entities.PaymentTransaction", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
