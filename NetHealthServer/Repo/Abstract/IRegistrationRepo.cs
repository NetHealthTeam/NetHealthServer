using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Abstract
{
    public interface IRegistrationRepo
    {
        public Task CreateUser(User user);
        public Task CheckEmailExistence(string email);
        public Task<int> GetActionId(string actionName);
        public Task CheckLoginCredentials(LoginRequest login);
    }
}
