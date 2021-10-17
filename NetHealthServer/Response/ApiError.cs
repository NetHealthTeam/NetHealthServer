using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Response
{
    public class ApiError
    {
        public ApiError() { }
        public ApiError(string error) : this() => ErrorMsg = error;
        public string ErrorMsg { get; set; }
    }
}
