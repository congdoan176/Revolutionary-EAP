﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Revolutionary.Data;

namespace Revolutionary.Migrations
{
    [DbContext(typeof(RevolutionaryContext))]
    [Migration("20190102161839_Reinitial")]
    partial class Reinitial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Revolutionary.Models.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Revolutionary.Models.AccountClazz", b =>
                {
                    b.Property<long>("AccountId");

                    b.Property<long>("ClazzId");

                    b.HasKey("AccountId", "ClazzId");

                    b.HasIndex("ClazzId");

                    b.ToTable("AccountClazzs");
                });

            modelBuilder.Entity("Revolutionary.Models.AccountInfomation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId");

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDay");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("AccountInfomation");
                });

            modelBuilder.Entity("Revolutionary.Models.AccountRole", b =>
                {
                    b.Property<long>("AccountId");

                    b.Property<int>("RoleId");

                    b.HasKey("AccountId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AccountRoles");
                });

            modelBuilder.Entity("Revolutionary.Models.Clazz", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Name");

                    b.Property<int>("Shift");

                    b.Property<int>("Status");

                    b.Property<long?>("TeacherId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Clazzes");
                });

            modelBuilder.Entity("Revolutionary.Models.Mark", b =>
                {
                    b.Property<long>("AccountId");

                    b.Property<long>("SubjectId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("Type");

                    b.Property<float>("Value");

                    b.HasKey("AccountId", "SubjectId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("Revolutionary.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Revolutionary.Models.Staff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AccountId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("DeletedAt");

                    b.Property<int>("Gender");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Revolutionary.Models.Subject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EndAt");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Revolutionary.Models.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("Revolutionary.Models.AccountClazz", b =>
                {
                    b.HasOne("Revolutionary.Models.Account", "Account")
                        .WithMany("AccountClazzes")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Revolutionary.Models.Clazz", "Clazz")
                        .WithMany("AccountClazzes")
                        .HasForeignKey("ClazzId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Revolutionary.Models.AccountInfomation", b =>
                {
                    b.HasOne("Revolutionary.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });

            modelBuilder.Entity("Revolutionary.Models.AccountRole", b =>
                {
                    b.HasOne("Revolutionary.Models.Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Revolutionary.Models.Role")
                        .WithMany("AccountRole")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Revolutionary.Models.Clazz", b =>
                {
                    b.HasOne("Revolutionary.Models.Teacher", "Teacher")
                        .WithMany("Clazzes")
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Revolutionary.Models.Mark", b =>
                {
                    b.HasOne("Revolutionary.Models.Account", "Account")
                        .WithMany("Marks")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Revolutionary.Models.Subject", "Subject")
                        .WithMany("Marks")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Revolutionary.Models.Staff", b =>
                {
                    b.HasOne("Revolutionary.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");
                });
#pragma warning restore 612, 618
        }
    }
}