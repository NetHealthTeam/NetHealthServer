using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Context;
using NetHealthServer.Data.Entities;
using NetHealthServer.Errors;
using NetHealthServer.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Concrete
{
    public class UserRepo : IUserRepo
    {
        private readonly NetHealthDbContext netHeakthDbContext;

        public UserRepo(NetHealthDbContext netHeakthDbContext)
        {
            this.netHeakthDbContext = netHeakthDbContext;
        }
        public async Task<User> GetUserByEmail(string email)
        {
            var user = await netHeakthDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
            if (user == null)
            {
                throw new CustomError("user_not_found");
            }
            return user;
        }
    }
}
