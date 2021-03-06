﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Revolutionary.Data;

namespace Revolutionary.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Revolutionary.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Session");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("Status");

                    b.Property<int>("SubjectId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Class");
                });

            modelBuilder.Entity("Revolutionary.Models.ClassRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("ClassRegister");
                });

            modelBuilder.Entity("Revolutionary.Models.InviteCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("RoleId");

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("InviteCode");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "AAAAAA",
                            CreatedAt = new DateTime(2019, 1, 8, 13, 8, 53, 204, DateTimeKind.Local).AddTicks(466),
                            RoleId = 1,
                            Status = 1,
                            UpdatedAt = new DateTime(2019, 1, 8, 13, 8, 53, 205, DateTimeKind.Local).AddTicks(4497)
                        },
                        new
                        {
                            Id = 2,
                            Code = "BBBBBB",
                            CreatedAt = new DateTime(2019, 1, 8, 13, 8, 53, 205, DateTimeKind.Local).AddTicks(6964),
                            RoleId = 0,
                            Status = 1,
                            UpdatedAt = new DateTime(2019, 1, 8, 13, 8, 53, 205, DateTimeKind.Local).AddTicks(6967)
                        });
                });

            modelBuilder.Entity("Revolutionary.Models.Mark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Assignment");

                    b.Property<int>("ClassId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<float>("Penalty");

                    b.Property<float>("Practical");

                    b.Property<int>("Status");

                    b.Property<float>("Theory");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("Mark");
                });

            modelBuilder.Entity("Revolutionary.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("Revolutionary.Models.User", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Class")
                        .IsRequired();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("StudentCode")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Revolutionary.Models.Class", b =>
                {
                    b.HasOne("Revolutionary.Models.Subject", "Subject")
                        .WithMany("Classes")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Revolutionary.Models.ClassRegister", b =>
                {
                    b.HasOne("Revolutionary.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Revolutionary.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Revolutionary.Models.Mark", b =>
                {
                    b.HasOne("Revolutionary.Models.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Revolutionary.Models.User", "User")
                        .WithMany("Marks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
