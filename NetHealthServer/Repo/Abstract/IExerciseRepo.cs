using NetHealthServer.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Abstract
{
  public  interface IExerciseRepo
    {
        public Task<List<Exercise>> GetAllExercises();
    }
}
