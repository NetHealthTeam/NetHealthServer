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

        public RegistrationService(IRegistrationRepo registrationRepo, IJwtAuthenticationManager authenticationManager)
        {
            this.registrationRepo = registrationRepo;
            this.authenticationManager = authenticationManager;
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
                AmountOfCalories = registrationRequest.AmountOfCalories,
                ActionId=actionId,
                NutritionProgramId=null,
                GymProgramId=null,
                
            };
            await registrationRepo.CreateUser(user);
        }
    }
}
