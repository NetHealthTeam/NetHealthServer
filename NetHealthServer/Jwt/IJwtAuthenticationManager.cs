using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Jwt
{
   public interface IJwtAuthenticationManager
    {
        public Task<string> Authenticate(string email);

    }
}
