﻿// <auto-generated />
using System;
using ForcWebApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ForcWebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230914084958_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DishUserDishCollection", b =>
                {
                    b.Property<Guid>("DishesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserDishCollectionsId")
                        .HasColumnType("uuid");

                    b.HasKey("DishesId", "UserDishCollectionsId");

                    b.HasIndex("UserDishCollectionsId");

                    b.ToTable("DishUserDishCollection");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.CompositionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<double>("ProductWeightG")
                        .HasColumnType("double precision");

                    b.Property<Guid>("ResourseSpecificationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ResourseSpecificationId");

                    b.ToTable("CompositionItem");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.DailyRate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("CaloriesRate")
                        .HasColumnType("double precision");

                    b.Property<double>("CarbohydrateRate")
                        .HasColumnType("double precision");

                    b.Property<double>("FatRate")
                        .HasColumnType("double precision");

                    b.Property<double>("ProteinRate")
                        .HasColumnType("double precision");

                    b.Property<Guid>("TargetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("DailyRate");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ResourseSpecificationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ResourseSpecificationId");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Meal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("MealTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId1")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("Meal");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.MealItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uuid");

                    b.Property<double>("DishWeightG")
                        .HasColumnType("double precision");

                    b.Property<Guid>("MealId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("MealItem");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.PhysicalActivityCatalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PhysicalActivityMultiplier")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("PhysicalActivityCatalog");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Calories")
                        .HasColumnType("double precision");

                    b.Property<double>("Carbohydrate")
                        .HasColumnType("double precision");

                    b.Property<double>("Fat")
                        .HasColumnType("double precision");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Protein")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.ResourseSpecification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uuid");

                    b.Property<double>("OutputDishWeightG")
                        .HasColumnType("double precision");

                    b.Property<Guid>("SpecNutritionValueId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SpecNutritionValueId");

                    b.ToTable("ResourseSpecification");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.SpecNutritionValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Calories")
                        .HasColumnType("double precision");

                    b.Property<double>("Carbohydrate")
                        .HasColumnType("double precision");

                    b.Property<double>("Fat")
                        .HasColumnType("double precision");

                    b.Property<double>("Protein")
                        .HasColumnType("double precision");

                    b.Property<Guid>("ResourseSpecificationId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("SpecNutritionValue");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Target", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("CurrentBodyWeight")
                        .HasColumnType("double precision");

                    b.Property<Guid>("DailyRateId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Relevance")
                        .HasColumnType("boolean");

                    b.Property<double>("TargetBodyWeight")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId1")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DailyRateId");

                    b.HasIndex("UserId1");

                    b.ToTable("Target");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("Gender")
                        .HasColumnType("text");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PhysicalActivityId")
                        .HasColumnType("uuid");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int?>("Sex")
                        .HasColumnType("integer");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<Guid>("UserDishCollectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("PhysicalActivityId");

                    b.HasIndex("UserDishCollectionId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.UserDishCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("UserDishCollection");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.WeightCondition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("BodyWeight")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserId1")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId1");

                    b.ToTable("WeightCondition");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DishUserDishCollection", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForcWebApi.Infrastructure.Entities.UserDishCollection", null)
                        .WithMany()
                        .HasForeignKey("UserDishCollectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.CompositionItem", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.Product", null)
                        .WithMany("CompositionItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForcWebApi.Infrastructure.Entities.ResourseSpecification", null)
                        .WithMany("Composition")
                        .HasForeignKey("ResourseSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Dish", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.ResourseSpecification", "ResourseSpecification")
                        .WithMany()
                        .HasForeignKey("ResourseSpecificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ResourseSpecification");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Meal", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany("Meals")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.MealItem", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.Meal", null)
                        .WithMany("MealItems")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.ResourseSpecification", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.SpecNutritionValue", "SpecNutritionValue")
                        .WithMany()
                        .HasForeignKey("SpecNutritionValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpecNutritionValue");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Target", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.DailyRate", "DailyRate")
                        .WithMany()
                        .HasForeignKey("DailyRateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany("Targets")
                        .HasForeignKey("UserId1");

                    b.Navigation("DailyRate");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.User", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.PhysicalActivityCatalog", "PhysicalActivity")
                        .WithMany()
                        .HasForeignKey("PhysicalActivityId");

                    b.HasOne("ForcWebApi.Infrastructure.Entities.UserDishCollection", "UserDishCollection")
                        .WithMany()
                        .HasForeignKey("UserDishCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhysicalActivity");

                    b.Navigation("UserDishCollection");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.WeightCondition", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany("WeightConditions")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ForcWebApi.Infrastructure.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Meal", b =>
                {
                    b.Navigation("MealItems");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.Product", b =>
                {
                    b.Navigation("CompositionItems");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.ResourseSpecification", b =>
                {
                    b.Navigation("Composition");
                });

            modelBuilder.Entity("ForcWebApi.Infrastructure.Entities.User", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("Targets");

                    b.Navigation("WeightConditions");
                });
#pragma warning restore 612, 618
        }
    }
}