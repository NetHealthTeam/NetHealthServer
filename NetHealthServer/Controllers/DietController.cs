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
    public class DietController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IDietService dietService;

        public DietController(IUserService userService,IDietService dietService)
        {
            this.userService = userService;
            this.dietService = dietService;
        }
        [HttpGet("getdailydiet")]
        public async Task<DietResponse> GetDiet()
        {
            var email = User.Identity.Name;
            var user = await userService.GetUser(email);
            var result = await dietService.GetDailyDiet(user);
            return result;
        }
    }
}
