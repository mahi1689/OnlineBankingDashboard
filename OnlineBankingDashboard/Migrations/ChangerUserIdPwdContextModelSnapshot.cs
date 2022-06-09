﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBankingDashboard.Models;

#nullable disable

namespace OnlineBankingDashboard.Migrations
{
    [DbContext(typeof(ChangerUserIdPwdContext))]
    partial class ChangerUserIdPwdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineBankingDashboard.Models.Account", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("accno")
                        .HasColumnType("int");

                    b.Property<int>("balance")
                        .HasColumnType("int");

                    b.Property<DateTime?>("created")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("OnlineBankingDashboard.Models.ChangerUserIdPwdContexts", b =>
                {
                    b.Property<int>("AccountNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountNumber"), 1L, 1);

                    b.Property<string>("ConfirmLoginPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConfirmTransactionPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnterOtp")
                        .HasColumnType("int");

                    b.Property<string>("LoginPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountNumber");

                    b.ToTable("ChangerUserIdPwdContexts");
                });

            modelBuilder.Entity("OnlineBankingDashboard.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("accountid")
                        .HasColumnType("int");

                    b.Property<int>("mobile")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("accountid");

                    b.ToTable("users");
                });

            modelBuilder.Entity("OnlineBankingDashboard.Models.User", b =>
                {
                    b.HasOne("OnlineBankingDashboard.Models.Account", "account")
                        .WithMany()
                        .HasForeignKey("accountid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("account");
                });
#pragma warning restore 612, 618
        }
    }
}
