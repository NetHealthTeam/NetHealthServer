using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Abstract
{
    public interface IWorkoutService
    {
        public Task<List<Workout>> GenerateWorkouts(RegistrationRequest registrationRequest);
    }
}
