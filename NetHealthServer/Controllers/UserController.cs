using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("personalcabinet")]
        public async Task<ApiValueResponse<UserResponse>> GetPersonalCabinet()
        {
            var email = User.Identity.Name;
            var user=await userService.GetPersonalCabinet(email);
            return new ApiValueResponse<UserResponse>(user);
        }
    }
}
