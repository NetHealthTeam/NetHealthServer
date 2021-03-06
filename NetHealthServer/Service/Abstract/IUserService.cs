using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Abstract
{
    public interface IUserService
    {
        public Task<UserResponse> GetPersonalCabinet(string email);
        public Task<User> GetUser(string email);
    }
}
