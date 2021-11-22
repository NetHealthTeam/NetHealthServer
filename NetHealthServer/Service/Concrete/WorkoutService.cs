using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Request;
using NetHealthServer.Repo.Abstract;
using NetHealthServer.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Concrete
{
    public class WorkoutService : IWorkoutService

    {
        private readonly IWorkoutRepo workoutRepo;
        private readonly IExerciseRepo exerciseRepo;

        public WorkoutService(IWorkoutRepo workoutRepo, IExerciseRepo exerciseRepo)
        {
            this.workoutRepo = workoutRepo;
            this.exerciseRepo = exerciseRepo;
        }
        private Task<List<int>> GenerateRandomNumber(int n,int max)
        {
            int minBorder = 0;
            int maxBorder =max;
            var randomExercisesIndexes = new List<int>();

            for (int i = 0; i < n; i++)
            {
                Random _rdm = new Random();
                var randomNumbers = _rdm.Next(minBorder, maxBorder);
                if (!randomExercisesIndexes.Contains(randomNumbers))
                {
                randomExercisesIndexes.Add(randomNumbers);

                }
                else
                {
                    i--;
                }

            }
            return Task.FromResult(randomExercisesIndexes);
        }
        public async Task<List<Workout>> GenerateWorkouts(RegistrationRequest registrationRequest)
        {
            var exercises = await exerciseRepo.GetAllExercises();
            var randomExercisesIndexes = new List<int>();

            List<Workout> workouts = new List<Workout>();
            if (registrationRequest.NumberOfGyms == 2)
            {
                randomExercisesIndexes = await GenerateRandomNumber(4, exercises.Count);
                var firstExercises = new List<Exercise>();
                firstExercises.Add(exercises[randomExercisesIndexes[0]]);
                firstExercises.Add(exercises[randomExercisesIndexes[1]]);
                var secondExercises = new List<Exercise>();
                secondExercises.Add(exercises[randomExercisesIndexes[2]]);
                secondExercises.Add(exercises[randomExercisesIndexes[3]]);
                Workout firstWorkout = new Workout()
                {
                    Name = registrationRequest.Email + "-tuesday",
                    MinutePerExercise = 60,
                    WeekDay = 2,
                    Exercises = firstExercises

                };
                Workout secondWorkout = new Workout()
                {
                    Name = registrationRequest.Email + "-Saturday",
                    MinutePerExercise = 60,
                    WeekDay = 6,
                    Exercises = secondExercises
                };
                workouts.Add(firstWorkout);
                workouts.Add(secondWorkout);

            }
            else
            {
                randomExercisesIndexes = await GenerateRandomNumber(6, exercises.Count);
                var firstExercises = new List<Exercise>();
                firstExercises.Add(exercises[randomExercisesIndexes[0]]);
                firstExercises.Add(exercises[randomExercisesIndexes[1]]);
                var secondExercises = new List<Exercise>();
                secondExercises.Add(exercises[randomExercisesIndexes[2]]);
                secondExercises.Add(exercises[randomExercisesIndexes[3]]);
                var thirdExercises = new List<Exercise>();
                thirdExercises.Add(exercises[randomExercisesIndexes[4]]);
                thirdExercises.Add(exercises[randomExercisesIndexes[5]]);
                Workout firstWorkout = new Workout()
                {
                    Name = registrationRequest.Email + "-tuesday",
                    MinutePerExercise = 45,
                    WeekDay = 2,
                    Exercises = firstExercises

                };
                Workout secondWorkout = new Workout()
                {
                    Name = registrationRequest.Email + "-thursday",
                    MinutePerExercise = 45,
                    WeekDay = 4,
                    Exercises = secondExercises
                };
                Workout thirdWorkout = new Workout()
                {
                    Name = registrationRequest.Email + "-saturday",
                    MinutePerExercise = 45,
                    WeekDay = 6,
                    Exercises = thirdExercises
                };
                workouts.Add(firstWorkout);
                workouts.Add(secondWorkout);
                workouts.Add(thirdWorkout);

            }
            return workouts;

        }
    }
}
