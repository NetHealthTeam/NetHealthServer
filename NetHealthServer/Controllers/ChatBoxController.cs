using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    
    public class ChatBoxController : ControllerBase
    {
        private readonly IChatBoxService chatBoxService;
        private readonly IUserService userService;

        public ChatBoxController(IChatBoxService chatBoxService,IUserService userService)
        {
            this.chatBoxService = chatBoxService;
            this.userService = userService;
        }
        [HttpPost("getinfo")]
        public async Task<ApiValueResponse<ChatBoxResponse>> GetInfo(ChatBoxRequest chatBoxRequest)
        {
            var email = User.Identity.Name;
            var user = await userService.GetUser(email);
           var result=  await chatBoxService.GetChatBoxResponse(chatBoxRequest,user);
            return new ApiValueResponse<ChatBoxResponse>(result);
        }

    }
}
