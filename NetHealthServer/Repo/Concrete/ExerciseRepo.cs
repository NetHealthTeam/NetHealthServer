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
    public class ExerciseRepo : IExerciseRepo
    {
        private readonly NetHealthDbContext netHealthDbContext;

        public ExerciseRepo(NetHealthDbContext netHealthDbContext)
        {
            this.netHealthDbContext = netHealthDbContext;
        }
        public async Task<List<Exercise>> GetAllExercises()
        {
           var exercises= await netHealthDbContext.Exercises.ToListAsync();
            return exercises;
        }
    }
}
