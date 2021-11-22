using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetHealthServer.Model.Response;
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
    public class GymController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IGymService gymService;

        public GymController(IUserService userService,IGymService gymService)
        {
            this.userService = userService;
            this.gymService = gymService;
        }
        [HttpGet("getgyminfo")]
        public async Task<List<GymResponse>> GetGymInfo()
        {
            var email = User.Identity.Name;
            var user = await userService.GetUser(email);
            var services = await gymService.GetDailyGymProgramByUser(user);


            return services;
        }
    }
}
