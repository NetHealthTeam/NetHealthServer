using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Response
{
    public class LoginResponse
    {
        
        public LoginResponse(string token)
        {
            Token = token;
        }

        public string Token { get; }
    }
}
