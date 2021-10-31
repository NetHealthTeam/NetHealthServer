﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetHealthServer.Data.Context;

namespace NetHealthServer.Migrations
{
    [DbContext(typeof(NetHealthDbContext))]
    [Migration("20211031190359_database structure completed")]
    partial class databasestructurecompleted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DietMeal", b =>
                {
                    b.Property<int>("DietsId")
                        .HasColumnType("int");

                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.HasKey("DietsId", "MealsId");

                    b.HasIndex("MealsId");

                    b.ToTable("diets_meals");
                });

            modelBuilder.Entity("DietNutritionProgram", b =>
                {
                    b.Property<int>("DietsId")
                        .HasColumnType("int");

                    b.Property<int>("NutritionProgramsId")
                        .HasColumnType("int");

                    b.HasKey("DietsId", "NutritionProgramsId");

                    b.HasIndex("NutritionProgramsId");

                    b.ToTable("nutritions_diets");
                });

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
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Action");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<short>("WeekDay")
                        .HasColumnType("smallint")
                        .HasColumnName("week_day");

                    b.HasKey("Id");

                    b.ToTable("Diet");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Calory")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("calory");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Exercise");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.GymProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Gym_program");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionId")
                        .HasColumnType("int")
                        .HasColumnName("action_id");

                    b.Property<decimal>("Calory")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("calory");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<short>("TimeOfDay")
                        .HasColumnType("smallint")
                        .HasColumnName("time_of_day");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.NutritionProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Nutrition_program");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionId")
                        .HasColumnType("int")
                        .HasColumnName("action_id");

                    b.Property<short>("Age")
                        .HasColumnType("smallint")
                        .HasColumnName("age");

                    b.Property<decimal>("AmountOfCalories")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("amount_of_calories");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("fullname");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("gender");

                    b.Property<int>("GymProgramId")
                        .HasColumnType("int")
                        .HasColumnName("gym_program_id");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("height");

                    b.Property<short>("NumberOfMeals")
                        .HasColumnType("smallint")
                        .HasColumnName("number_of_meals");

                    b.Property<int>("NutritionProgramId")
                        .HasColumnType("int")
                        .HasColumnName("nutrition_program_id");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)")
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
                        .HasColumnName("id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("DietMeal", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DietNutritionProgram", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Diet", null)
                        .WithMany()
                        .HasForeignKey("DietsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.NutritionProgram", null)
                        .WithMany()
                        .HasForeignKey("NutritionProgramsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.User", b =>
                {
                    b.HasOne("NetHealthServer.Data.Entities.Action", "Action")
                        .WithMany("Users")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.GymProgram", "GymProgram")
                        .WithMany("Users")
                        .HasForeignKey("GymProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetHealthServer.Data.Entities.NutritionProgram", "NutritProgram")
                        .WithMany("Users")
                        .HasForeignKey("NutritionProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("GymProgram");

                    b.Navigation("NutritProgram");
                });

            modelBuilder.Entity("NetHealthServer.Data.Entities.Action", b =>
                {
                    b.Navigation("Meals");

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