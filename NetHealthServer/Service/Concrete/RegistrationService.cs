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

        public RegistrationService(IRegistrationRepo registrationRepo, IJwtAuthenticationManager authenticationManager,INutritionRepo nutritionRepo)
        {
            this.registrationRepo = registrationRepo;
            this.authenticationManager = authenticationManager;
            this.nutritionRepo = nutritionRepo;
        }

        public async Task<LoginResponse> Login(LoginRequest login)
        {
            await registrationRepo.CheckLoginCredentials(login);
          var token= await authenticationManager.Authenticate(login.Email);
            LoginResponse loginResponse = new LoginResponse(token);
            return loginResponse;


        }

        public async Task CreateUser(RegistrationRequest registrationRequest)
        {
            await registrationRepo.CheckEmailExistence(registrationRequest.Email);
            var hashedPassword = new PasswordHasher<object?>().HashPassword(null, registrationRequest.Password);
            var actionId = await registrationRepo.GetActionId(registrationRequest.ActionName);
            var dailyCalory = await  CalculateDailyCalory(registrationRequest);
            var nutritionProgram = await nutritionRepo.GetNutritionProgram(actionId);
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
                GymProgramId=null,     
            };
            await registrationRepo.CreateUser(user);
        }
        private  Task<decimal> CalculateDailyCalory(RegistrationRequest registrationRequest)
        {
            decimal bmr = 0;
            bmr = 10 * registrationRequest.Weight + (decimal)6.25 * registrationRequest.Height * 100 - 5 * registrationRequest.Age;
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
