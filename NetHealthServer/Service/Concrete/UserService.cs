using NetHealthServer.Model.Response;
using NetHealthServer.Repo.Abstract;
using NetHealthServer.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IActionRepo actionRepo;

        public UserService(IUserRepo userRepo, IActionRepo actionRepo)
        {
            this.userRepo = userRepo;
            this.actionRepo = actionRepo;
        }
        public async Task<UserResponse> GetPersonalCabinet(string email)
        {
            var user = await userRepo.GetUserByEmail(email);
            var action = await actionRepo.GetActionById(user.ActionId);
            UserResponse userResponse = new UserResponse()
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                Weight = user.Weight,
                Height = user.Height,
                Age = user.Age,
                NumberOfGyms = user.NumberOfGyms,
                NumberOfMeals = user.NumberOfMeals,
                AmountOfCalories = user.AmountOfCalories,
                ActionName = action.Name


            };
            return userResponse;
        }
    }
}
