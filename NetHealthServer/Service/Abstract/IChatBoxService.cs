using NetHealthServer.Data.Entities;
using NetHealthServer.Model.Request;
using NetHealthServer.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Service.Abstract
{
    public interface IChatBoxService
    {
        public Task<ChatBoxResponse> GetChatBoxResponse(ChatBoxRequest chatBoxRequest,User user);

    }
}
