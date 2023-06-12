﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetClinic.DAL.DbContext;

#nullable disable

namespace PetClinic.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.AppointmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PetId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ReviewId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.DepartmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ddc19540-04df-4697-8237-3c74ff4e38cd"),
                            Address = "пр. Независимости, 177",
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Вет-клиника филиал 1",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("328b1872-1141-47f5-8f67-62c50562ad39"),
                            Address = "ул. Академическая, 26",
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Вет-клиника филиал 2",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("de1e6cc5-3e62-4459-9496-8a5fc0b2593f"),
                            Address = "ул. Карастояновой, 2",
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Вет-клиника филиал 3",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.OrderCallEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("OrderCalls");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.PetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("PetTypeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PetTypeId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.PetTypeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("PetTypes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0605974a-977c-4739-aa55-7e26e4eb2422"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Cat",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("c9a68d44-b5b8-4b96-9558-b4e52e750987"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Dog",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("13109317-ea78-4274-ad6e-e9a159f7f2f1"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Rabbit",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("a160449b-fb70-4991-9ddb-918b707829a8"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Parrot",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("f4dc2dab-9477-4ebe-8fb2-40306e739dee"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Hamster",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ReviewEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("VetComments")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.RoleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ServiceVetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("VetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ServiceId");

                    b.HasIndex("VetId");

                    b.ToTable("ServiceVets");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.StatusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2b513574-cabc-41ce-9fbc-e67255b84431"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Received",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("fb29bcb5-4493-4b03-b18e-11c50c650621"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Accepted",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("01b2b3b3-0f43-49c1-a138-dd39d76bb65a"),
                            CreatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc),
                            IsDeleted = false,
                            Name = "Closed",
                            UpdatedAt = new DateTime(2023, 6, 11, 23, 56, 3, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.VetEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uuid");

                    b.Property<int>("Experience")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("DepartmentId");

                    b.ToTable("Vets");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.RoleEntity", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetClinic.DAL.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.AppointmentEntity", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.PetEntity", "Pet")
                        .WithMany("Appointments")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetClinic.DAL.Entities.ReviewEntity", "Review")
                        .WithOne("Appointment")
                        .HasForeignKey("PetClinic.DAL.Entities.AppointmentEntity", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetClinic.DAL.Entities.ServiceVetEntity", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pet");

                    b.Navigation("Review");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.OrderCallEntity", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.StatusEntity", "Status")
                        .WithMany("OrderCalls")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.PetEntity", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.UserEntity", "User")
                        .WithMany("Pets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetClinic.DAL.Entities.PetTypeEntity", "PetType")
                        .WithMany("Pets")
                        .HasForeignKey("PetTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PetType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ServiceVetEntity", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.ServiceEntity", "Service")
                        .WithMany("ServiceVets")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetClinic.DAL.Entities.VetEntity", "Vet")
                        .WithMany("ServiceVets")
                        .HasForeignKey("VetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Vet");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.UserEntity", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.VetEntity", b =>
                {
                    b.HasOne("PetClinic.DAL.Entities.UserEntity", "User")
                        .WithOne("Vet")
                        .HasForeignKey("PetClinic.DAL.Entities.VetEntity", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetClinic.DAL.Entities.DepartmentEntity", "Department")
                        .WithMany("Vets")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.DepartmentEntity", b =>
                {
                    b.Navigation("Vets");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.PetEntity", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.PetTypeEntity", b =>
                {
                    b.Navigation("Pets");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ReviewEntity", b =>
                {
                    b.Navigation("Appointment")
                        .IsRequired();
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ServiceEntity", b =>
                {
                    b.Navigation("ServiceVets");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.ServiceVetEntity", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.StatusEntity", b =>
                {
                    b.Navigation("OrderCalls");
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.UserEntity", b =>
                {
                    b.Navigation("Pets");

                    b.Navigation("Vet")
                        .IsRequired();
                });

            modelBuilder.Entity("PetClinic.DAL.Entities.VetEntity", b =>
                {
                    b.Navigation("ServiceVets");
                });
#pragma warning restore 612, 618
        }
    }
}
