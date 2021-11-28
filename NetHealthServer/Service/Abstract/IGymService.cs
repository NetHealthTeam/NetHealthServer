using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Abstract
{
   public interface IGymService
    {
        public Task<GymProgram> GenerateGymProgram(string email,List<Workout> workouts);
        public Task<GymProgram> GetDailyGymProgram(string name);
        public Task<List<GymResponse>> GetDailyGymProgramByUser(User user);
        public Task<List<GymResponse>> GetGymProgram(User user, int? weekDay);
    }
}
