using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Context;
using NetHealthServer.Data.Entities;
using NetHealthServer.Errors;
using NetHealthServer.Model.Request;
using NetHealthServer.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Concrete
{
    public class RegistrationRepo : IRegistrationRepo
    {
        private readonly NetHealthDbContext netHealthDbContext;

        public RegistrationRepo(NetHealthDbContext netHealthDbContext)
        {
            this.netHealthDbContext = netHealthDbContext;
        }

        public async Task CheckEmailExistance(string email)
        {
            var user = await netHealthDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user != null)
            {
                throw new CustomError("email_dublicate_error");
            }
        }

        public async Task CheckLoginCredentials(LoginRequest login)
        {
            var user = await netHealthDbContext.Users.FirstOrDefaultAsync(x => x.Email == login.Email);
            if (user == null)
            {
                throw new CustomError("login_credentials_error");
            }
            var hashedPassword = new PasswordHasher<object?>();
            var result = hashedPassword.VerifyHashedPassword(user, user.Password, login.Password);
            if (result.ToString() == "Success")
            {
                return ;
            }
            throw new CustomError("login_credentials_error");

        }

        public async Task CreateUser(User user)
        {
            await netHealthDbContext.Users.AddAsync(user);
          var dbResult= await netHealthDbContext.SaveChangesAsync();
            if (dbResult <= 0)
            {
                throw new CustomError("create_error");
            }


        }

        public async Task<int> GetActionId(string actionName)
        {
            var result = await netHealthDbContext.Actions.FirstOrDefaultAsync(x => x.Name == actionName);
            if (result == null)
            {
                throw new CustomError("action_not_found");

            }
            return result.Id;
        }
    }
}
