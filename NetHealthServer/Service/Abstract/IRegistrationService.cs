using NetHealthServer.Model.Request;
using NetHealthServer.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Abstract
{
   public interface IRegistrationService
    {
        public Task CreateUser(RegistrationRequest registrationRequest);
        public Task<LoginResponse> Login(LoginRequest login);

    }
}
