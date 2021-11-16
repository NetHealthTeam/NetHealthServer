﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetHealthServer.Data.Context;

namespace NetHealthServer.Migrations
{
    [DbContext(typeof(NetHealthDbContext))]
    [Migration("20211116173716_Seed-data added")]
    partial class Seeddataadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.Property<int>("ExercisesId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutsId")
                        .HasColumnType("int");

                    b.HasKey("ExercisesId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("workouts_exercises");
                });

            modelBuilder.Entity("GymProgramWorkout", b =>
                {
                    b.Property<int>("GymProgramsId")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutsId")
                        .HasColumnType("int");

                    b.HasKey("GymProgramsId", "WorkoutsId");

                    b.HasIndex("WorkoutsId");

                    b.ToTable("gym_workouts");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<short>("WeekDay")
                        .HasColumnType("smallint")
                        .HasColumnName("week_day");

                    b.HasKey("Id");

                    b.ToTable("Diet");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Name = "monday_first_menu",
                            WeekDay = (short)2
                        });
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<decimal>("Calory")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("calory");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.GymProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Gym_program");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int?>("ActionId")
                        .HasColumnType("int")
                        .HasColumnName("action_id");

                    b.Property<string>("Amount")
                        .HasColumnType("longtext")
                        .HasColumnName("amount");

                    b.Property<decimal>("Calory")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("calory");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("image_url");

                    b.Property<string>("MealUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("meal_url");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.Property<short>("TimeOfDay")
                        .HasColumnType("smallint")
                        .HasColumnName("time_of_day");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 7,
                            Amount = "80",
                            Calory = 267.2m,
                            ImageUrl = "https://images.eatthismuch.com/site_media/img/1112_erin_m_82150710-3374-4cb8-94cc-7071559fce2b.png",
                            MealUrl = "https://www.eatthismuch.com/food/nutrition/oatmeal,1112/",
                            Name = "Oatmeal",
                            TimeOfDay = (short)1
                        },
                        new
                        {
                            Id = 8,
                            Amount = "140",
                            Calory = 221.2m,
                            ImageUrl = "https://images.eatthismuch.com/site_media/img/4857_laurabedo_da2c9648-14a9-47fd-bff3-3c1d66ad3fa7.png",
                            MealUrl = "https://www.eatthismuch.com/food/nutrition/macaroni,4857/",
                            Name = "Macaroni",
                            TimeOfDay = (short)2
                        },
                        new
                        {
                            Id = 9,
                            Amount = "168",
                            Calory = 154.6m,
                            ImageUrl = "https://images.eatthismuch.com/site_media/img/4778_cyberchristie_6edef096-491d-4559-8df0-3281552ba4af.png",
                            MealUrl = "https://www.eatthismuch.com/food/nutrition/buckwheat-groats,4778/",
                            Name = "Buckwheat groats",
                            TimeOfDay = (short)2
                        },
                        new
                        {
                            Id = 10,
                            Amount = "555",
                            Calory = 253m,
                            ImageUrl = "https://images.eatthismuch.com/site_media/img/45207_tabitharwheeler_50bb20bd-abb6-4373-90d6-dece7b636b16.jpg",
                            MealUrl = "https://www.eatthismuch.com/recipe/nutrition/perfect-steamed-rice,45207/",
                            Name = "Perfect Steamed Rice",
                            TimeOfDay = (short)3
                        });
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.NutritionProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("ActionId")
                        .HasColumnType("int")
                        .HasColumnName("action_id");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("Nutrition_program");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ActionId = 1,
                            Name = "first_up"
                        });
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ActionId")
                        .HasColumnType("int")
                        .HasColumnName("action_id");

                    b.Property<short>("Age")
                        .HasColumnType("smallint")
                        .HasColumnName("age");

                    b.Property<decimal>("AmountOfCalories")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("amount_of_calories");

                    b.Property<string>("Email")
                        .HasColumnType("longtext")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("longtext")
                        .HasColumnName("fullname");

                    b.Property<string>("Gender")
                        .HasColumnType("longtext")
                        .HasColumnName("gender");

                    b.Property<int?>("GymProgramId")
                        .HasColumnType("int")
                        .HasColumnName("gym_program_id");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("height");

                    b.Property<short>("NumberOfGyms")
                        .HasColumnType("smallint")
                        .HasColumnName("number_of_gyms");

                    b.Property<short>("NumberOfMeals")
                        .HasColumnType("smallint")
                        .HasColumnName("number_of_meals");

                    b.Property<int?>("NutritionProgramId")
                        .HasColumnType("int")
                        .HasColumnName("nutrition_program_id");

                    b.Property<string>("Password")
                        .HasColumnType("longtext")
                        .HasColumnName("password");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("weight");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("GymProgramId");

                    b.HasIndex("NutritionProgramId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("longtext")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("diets_meals", b =>
                {
                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.HasKey("DietId", "MealId");

                    b.HasIndex("MealId");

                    b.ToTable("diets_meals");

                    b.HasData(
                        new
                        {
                            DietId = 2,
                            MealId = 7
                        },
                        new
                        {
                            DietId = 2,
                            MealId = 8
                        },
                        new
                        {
                            DietId = 2,
                            MealId = 9
                        },
                        new
                        {
                            DietId = 2,
                            MealId = 10
                        });
                });

            modelBuilder.Entity("nutrutions_diets", b =>
                {
                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("NutritionProgramId")
                        .HasColumnType("int");

                    b.HasKey("DietId", "NutritionProgramId");

                    b.HasIndex("NutritionProgramId");

                    b.ToTable("nutrutions_diets");

                    b.HasData(
                        new
                        {
                            DietId = 2,
                            NutritionProgramId = 2
                        });
                });

            modelBuilder.Entity("ExerciseWorkout", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Exercise", null)
                        .WithMany()
                        .HasForeignKey("ExercisesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GymProgramWorkout", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.GymProgram", null)
                        .WithMany()
                        .HasForeignKey("GymProgramsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.Workout", null)
                        .WithMany()
                        .HasForeignKey("WorkoutsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Meal", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Action", "Action")
                        .WithMany("Meals")
                        .HasForeignKey("ActionId");

                    b.Navigation("Action");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.NutritionProgram", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Action", null)
                        .WithMany("NutritionPrograms")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.User", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Action", "Action")
                        .WithMany("Users")
                        .HasForeignKey("ActionId");

                    b.HasOne("NetHealthServer.Data.Entities.GymProgram", "GymProgram")
                        .WithMany("Users")
                        .HasForeignKey("GymProgramId");

                    b.HasOne("NetHealthServer.Data.Entities.NutritionProgram", "NutritProgram")
                        .WithMany("Users")
                        .HasForeignKey("NutritionProgramId");

                    b.Navigation("Action");

                    b.Navigation("GymProgram");

                    b.Navigation("NutritProgram");
                });

            modelBuilder.Entity("diets_meals", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("nutrutions_diets", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.NutritionProgram", null)
                        .WithMany()
                        .HasForeignKey("NutritionProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Action", b =>
                {
                    b.Navigation("Meals");

                    b.Navigation("NutritionPrograms");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.GymProgram", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.NutritionProgram", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
