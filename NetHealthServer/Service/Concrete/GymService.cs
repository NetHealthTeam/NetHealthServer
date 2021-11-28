using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Response;
using NetHealthServer.Repo.Abstract;
using NetHealthServer.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Concrete
{
    public class GymService : IGymService
    {
        private readonly IGymRepo gymRepo;

        public GymService(IGymRepo gymRepo)
        {
            this.gymRepo = gymRepo;
        }
        public async Task<GymProgram> GenerateGymProgram(string email, List<Workout> workouts)
        {
            GymProgram gymProgram = new GymProgram()
            {
                Name = email + "-gym",
                Workouts=workouts
            };
           
            var result = await gymRepo.CreateGymProgram(gymProgram);
            return result;

        }

        public async Task<GymProgram> GetDailyGymProgram(string name)
        {
            var result = await gymRepo.GetDailyGymProgram(name);
            return result;
        }

        public async Task<List<GymResponse>> GetDailyGymProgramByUser(User user)
        {
            var gymProgram = await gymRepo.GetDailyGymProgramById(user.GymProgramId);
            var workouts = gymProgram.Workouts;
            List<GymResponse> gymResponses = new List<GymResponse>();
            foreach (var workout in workouts)
            {
                var exercises = workout.Exercises;
                foreach (var exercise in exercises)
                {

                    GymResponse gymResponse = new GymResponse()
                    {
                        Id = exercise.Id,
                        Name = exercise.Name,
                        ImageUrl = exercise.ImageUrl,
                        CaloriePerHour = exercise.CaloryPerHour,
                        Duration = workout.MinutePerExercise,
                        Weekday = workout.WeekDay



                    };
                    gymResponses.Add(gymResponse);
                }
            }
            return gymResponses;
        }

        public async Task<List<GymResponse>> GetGymProgram(User user, int? weekDay)
        {
            var gymProgram = await gymRepo.GetDailyGymProgramById(user.GymProgramId);
            var workout = gymProgram.Workouts.FirstOrDefault(x => x.WeekDay == weekDay);
            var exercises = workout.Exercises;
            List<GymResponse> gymResponses = new List<GymResponse>();

            foreach (var exercise in exercises)
            {

                GymResponse gymResponse = new GymResponse()
                {
                    Id = exercise.Id,
                    Name = exercise.Name,
                    ImageUrl = exercise.ImageUrl,
                    CaloriePerHour = exercise.CaloryPerHour,
                    Duration = workout.MinutePerExercise,
                    Weekday = workout.WeekDay



                };
                gymResponses.Add(gymResponse);

            }
            return gymResponses;
        }
    }
}
