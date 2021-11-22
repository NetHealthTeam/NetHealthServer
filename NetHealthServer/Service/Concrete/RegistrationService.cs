using Microsoft.AspNetCore.Identity;
using NetHealthServer.Data.Entities;
using NetHealthServer.Jwt;
using NetHealthServer.Model.Request;
using NetHealthServer.Model.Response;
using NetHealthServer.Repo.Abstract;
using NetHealthServer.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Concrete
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepo registrationRepo;
        private readonly IJwtAuthenticationManager authenticationManager;
        private readonly INutritionRepo nutritionRepo;
        private readonly IGymService gymService;
        private readonly IWorkoutService workoutService;

        public RegistrationService(IRegistrationRepo registrationRepo, IJwtAuthenticationManager authenticationManager,INutritionRepo nutritionRepo,IGymService gymService,IWorkoutService workoutService)
        {
            this.registrationRepo = registrationRepo;
            this.authenticationManager = authenticationManager;
            this.nutritionRepo = nutritionRepo;
            this.gymService = gymService;
            this.workoutService = workoutService;
        }

        public async Task<LoginResponse> Login(LoginRequest login)
        {
            await registrationRepo.CheckLoginCredentials(login);
          var token= await authenticationManager.Authenticate(login.Email);
            LoginResponse loginResponse = new LoginResponse(token);
            return loginResponse;


        }

        public async Task<User> CreateUser(RegistrationRequest registrationRequest)
        {
            await registrationRepo.CheckEmailExistence(registrationRequest.Email);
            var hashedPassword = new PasswordHasher<object?>().HashPassword(null, registrationRequest.Password);
            var actionId = await registrationRepo.GetActionId(registrationRequest.ActionName);
            var dailyCalory = await  CalculateDailyCalory(registrationRequest);
            var nutritionProgram = await nutritionRepo.GetNutritionProgram(actionId);
            var workouts = await workoutService.GenerateWorkouts(registrationRequest);
            var gymProgram = await gymService.GenerateGymProgram(registrationRequest.Email,workouts);
           
            User user = new User()
            {
                Email = registrationRequest.Email,
                Password=hashedPassword,
                FullName = registrationRequest.Fullname,
                Gender = registrationRequest.Gender,
                Age = registrationRequest.Age,
                Weight = registrationRequest.Weight,
                Height = registrationRequest.Height,
                NumberOfMeals = registrationRequest.NumberOfMeals,
                NumberOfGyms = registrationRequest.NumberOfGyms,
                AmountOfCalories = dailyCalory,
                ActionId=actionId,
                NutritionProgramId=nutritionProgram.Id,
                NutritProgram=nutritionProgram,
                GymProgramId=gymProgram.Id,     
            };

            await registrationRepo.CreateUser(user);
            return user;
        }
        private  Task<decimal> CalculateDailyCalory(RegistrationRequest registrationRequest)
        {
            decimal bmr = 0;
            bmr = 10 * registrationRequest.Weight + (decimal)6.25 * registrationRequest.Height  - 5 * registrationRequest.Age;
            if (registrationRequest.Gender=="Male")
            {
                bmr += 5;
            }
            else
            {
                bmr -= 161;
            }
            bmr *= (decimal)1.375;
            if (registrationRequest.ActionName == "Gain Weight")
            {
                bmr += 300;
            }
            else
            {
                bmr -= 500;
            }
            return Task.FromResult(bmr);
        }
    }
}
