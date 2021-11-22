using NetHealthServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Abstract
{
    public interface IGymRepo
    {
        public Task<GymProgram> CreateGymProgram(GymProgram gymProgram);
        public Task<GymProgram> GetDailyGymProgram(string name);
        public Task<GymProgram> GetDailyGymProgramById(int? id);


    }
}
