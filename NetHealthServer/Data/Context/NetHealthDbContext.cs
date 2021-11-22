using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Context
{
    public class NetHealthDbContext : DbContext
    {
        public NetHealthDbContext( DbContextOptions<NetHealthDbContext> options)
            :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<NutritionProgram> NutritionPrograms { get; set; }
        public DbSet<GymProgram> GymPrograms { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Entities.Action> Actions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>().HasMany(p => p.GymPrograms).WithMany(p => p.Workouts).UsingEntity(j => j.ToTable("gym_workouts"));
            modelBuilder.Entity<Exercise>().HasMany(p => p.Workouts).WithMany(p => p.Exercises).UsingEntity(j => j.ToTable("workouts_exercises"));
           
           
            modelBuilder.Entity<NutritionProgram>().HasMany(p => p.Diets).WithMany(p => p.NutritionPrograms).UsingEntity<Dictionary<string, object>>(
                "nutrutions_diets",
                r => r.HasOne<Diet>().WithMany().HasForeignKey("DietId"),
                 l => l.HasOne<NutritionProgram>().WithMany().HasForeignKey("NutritionProgramId"),
                  je =>
                  {
                      je.HasKey("DietId", "NutritionProgramId");
                      je.HasData(
                          new { DietId = 2, NutritionProgramId = 2 },
                          new { DietId = 3, NutritionProgramId = 3 }





                          );
                        


                  }
                );
            modelBuilder.Entity<Meal>().HasMany(p => p.Diets).WithMany(p => p.Meals).UsingEntity<Dictionary<string, object>>(
                "diets_meals",
                r => r.HasOne<Diet>().WithMany().HasForeignKey("DietId"),
                 l => l.HasOne<Meal>().WithMany().HasForeignKey("MealId"),
                  je =>
                  {
                      je.HasKey("DietId", "MealId");
                      je.HasData(
                          new { DietId = 2, MealId = 7 },
                          new { DietId = 2, MealId = 8 },
                          new { DietId = 2, MealId = 9 },
                          new { DietId = 2, MealId = 10 },
                          new { DietId = 3, MealId = 7 },
                          new { DietId = 3, MealId = 8 },
                          new { DietId = 3, MealId = 9 },
                          new { DietId = 3, MealId = 10 });
                          
                  }
                );
            Diet diet = new Diet()
            {
                Id = 2,
                Name = "wednesday_gain_menu",
                WeekDay = 3,


            };

            modelBuilder.Entity<Entities.Action>().HasData(
                new Entities.Action()
                {
                    Id = 1,
                    Name = "Loose Weight"
                },
                new Entities.Action()
                {
                    Id = 2,
                    Name = "Gain Weight"
                });
            modelBuilder.Entity<Diet>().HasData(
                diet,
                new Diet()
                {
                    Id=3,
                    Name="wednesday_loose_menu",
                    WeekDay=3

                }
                );
            modelBuilder.Entity<Meal>().HasData(
                new Meal()
                {
                    Id = 7,
                    Name = "Oatmeal",
                    Calory = (decimal)267.2,
                    TimeOfDay = 1,
                    ImageUrl = "https://images.eatthismuch.com/site_media/img/1112_erin_m_82150710-3374-4cb8-94cc-7071559fce2b.png",
                    MealUrl = "https://www.eatthismuch.com/food/nutrition/oatmeal,1112/",
                    Amount = "80",


                },
                new Meal()
                {
                    Id = 8,
                    Name = "Macaroni",
                    Calory = (decimal)221.2,
                    TimeOfDay = 2,
                    ImageUrl = "https://images.eatthismuch.com/site_media/img/4857_laurabedo_da2c9648-14a9-47fd-bff3-3c1d66ad3fa7.png",
                    MealUrl = "https://www.eatthismuch.com/food/nutrition/macaroni,4857/",
                    Amount = "140",


                },
                new Meal()
                {
                    Id = 9,
                    Name = "Buckwheat groats",
                    Calory = (decimal)154.6,
                    TimeOfDay = 2,
                    ImageUrl = "https://images.eatthismuch.com/site_media/img/4778_cyberchristie_6edef096-491d-4559-8df0-3281552ba4af.png",
                    MealUrl = "https://www.eatthismuch.com/food/nutrition/buckwheat-groats,4778/",
                    Amount = "168",


                },
                new Meal()
                {
                    Id = 10,
                    Name = "Perfect Steamed Rice",
                    Calory = (decimal)253,
                    TimeOfDay = 3,
                    ImageUrl = "https://images.eatthismuch.com/site_media/img/45207_tabitharwheeler_50bb20bd-abb6-4373-90d6-dece7b636b16.jpg",
                    MealUrl = "https://www.eatthismuch.com/recipe/nutrition/perfect-steamed-rice,45207/",
                    Amount = "555",


                }
                );
            NutritionProgram nutritionProgram = new NutritionProgram()
            {
                Id = 2,
                Name = "first_up",
                ActionId = 2,

            };
            modelBuilder.Entity<NutritionProgram>().HasData(
                nutritionProgram,
                new NutritionProgram()
                {
                    Id=3,
                    Name="first_down",
                    ActionId = 1
                }

                );
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise()
                {
                    Id=1,
                    Name= "Jumping Rope",
                    CaloryPerHour="667-990",
                    ImageUrl= "https://static.toiimg.com/photo/71956822.cms"
                },
                new Exercise()
                {
                    Id = 2,
                    Name = "Running",
                    CaloryPerHour = "566-839",
                    ImageUrl = "https://post.healthline.com/wp-content/uploads/2020/01/Runner-training-on-running-track-732x549-thumbnail.jpg"
                },
                new Exercise()
                {
                    Id = 3,
                    Name = "Cycling",
                    CaloryPerHour = "568-841",
                    ImageUrl = "https://cdn.mos.cms.futurecdn.net/M825uvxzJE2MDmqSfFb7PY.jpg"
                },
                new Exercise()
                {
                    Id = 4,
                    Name = "Stairs",
                    CaloryPerHour = "452-670",
                    ImageUrl = "https://www.muscleandfitness.com/wp-content/uploads/2019/06/man-running-stairs-1109.jpg?w=940&h=529&crop=1&quality=86&strip=all"
                },
                 new Exercise()
                 {
                     Id = 5,
                     Name = "Running Up Hills",
                     CaloryPerHour = "639-946",
                     ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/766/runninguphill-1501799541.jpg"
                 },
                  new Exercise()
                  {
                      Id = 6,
                      Name = "Yoga",
                      CaloryPerHour = "226-335",
                      ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/766/runninguphill-1501799541.jpg"
                  }
                );



        }


    }
}
