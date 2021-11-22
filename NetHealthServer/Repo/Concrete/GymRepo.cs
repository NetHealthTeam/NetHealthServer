using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Context;
using NetHealthServer.Data.Entities;
using NetHealthServer.Errors;
using NetHealthServer.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Concrete
{
    public class GymRepo : IGymRepo
    {
        private readonly NetHealthDbContext netHealthDb;

        public GymRepo(NetHealthDbContext netHealthDb)
        {
            this.netHealthDb = netHealthDb;
        }
        public async Task<GymProgram> CreateGymProgram(GymProgram gymProgram)
        {
            
           await netHealthDb.GymPrograms.AddAsync(gymProgram);
           
            var result = await netHealthDb.SaveChangesAsync();
            if (result <= 0)
            {
                throw new CustomError("gym_program_create_error");
            }



            return gymProgram;
        }

        public async Task<GymProgram> GetDailyGymProgramById(int? id)
        {
            var gymProgram = await netHealthDb.GymPrograms.Include(x => x.Workouts).ThenInclude(x => x.Exercises).FirstOrDefaultAsync(x=>x.Id==id);
            return gymProgram;

           
        }

        public async Task<GymProgram> GetDailyGymProgram(string name)
        {
            var result = await netHealthDb.GymPrograms.FirstOrDefaultAsync(x => x.Name == name);
            return result;
        }
    }
}
