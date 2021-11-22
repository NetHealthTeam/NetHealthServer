using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Context;
using NetHealthServer.Data.Entities;
using NetHealthServer.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Concrete
{
    public class WorkoutRepo : IWorkoutRepo
    {
        private readonly NetHealthDbContext netHealthDbContext;

        public WorkoutRepo(NetHealthDbContext netHealthDbContext)
        {
            this.netHealthDbContext = netHealthDbContext;
        }
        public async Task<List<Workout>> GetAllWorkouts()
        {
            var workouts = await netHealthDbContext.Workouts.ToListAsync();
            return workouts;
            
        }
    }
}
