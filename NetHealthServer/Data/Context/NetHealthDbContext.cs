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
            modelBuilder.Entity<NutritionProgram>().HasMany(p => p.Diets).WithMany(p => p.NutritionPrograms).UsingEntity(j => j.ToTable("nutritions_diets"));
            modelBuilder.Entity<Meal>().HasMany(p => p.Diets).WithMany(p => p.Meals).UsingEntity(j => j.ToTable("diets_meals"));
            modelBuilder.Entity<Workout>().HasMany(p => p.GymPrograms).WithMany(p => p.Workouts).UsingEntity(j => j.ToTable("gym_workouts"));
            modelBuilder.Entity<Exercise>().HasMany(p => p.Workouts).WithMany(p => p.Exercises).UsingEntity(j => j.ToTable("workouts_exercises"));
        }


    }
}
