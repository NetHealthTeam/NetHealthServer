using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetHealthServer.Model.Request;
using NetHealthServer.Model.Response;
using NetHealthServer.Response;
using NetHealthServer.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService registration;

        public RegistrationController(IRegistrationService registration)
        {
            this.registration = registration;
        }
        [HttpPost("registration")]
        public async Task<ApiResponse> Registration(RegistrationRequest registrationRequest)
        {
            if (ModelState.IsValid)
            {
                await registration.CreateUser(registrationRequest);

            }
            return new ApiResponse();
        }
        [HttpPost("signin")]
        public async Task<ApiValueResponse<LoginResponse>> Login(LoginRequest loginRequest)
        {
            var result = await registration.Login(loginRequest);

            return new ApiValueResponse<LoginResponse>(result);
        }
    }
}
