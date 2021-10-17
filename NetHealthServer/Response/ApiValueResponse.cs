using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Response
{
    public class ApiValueResponse<T> : ApiResponse
    {
        public ApiValueResponse(T value) => Value = value;
        public ApiValueResponse()
        {

        }
        public ApiValueResponse(string error) : base(error) { }

        public T Value { get; set; }
    }
}
