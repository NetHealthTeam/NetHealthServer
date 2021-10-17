using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Response
{
    public class ApiResponse
    {
        public bool Success { get => Errors == null || Errors.Count() == 0; }
        public List<ApiError> Errors { get; set; }
        public ApiResponse() => Errors = new List<ApiError>();
        public ApiResponse(string error) : this() => Errors.Add(new ApiError { ErrorMsg = error });
    }
}
