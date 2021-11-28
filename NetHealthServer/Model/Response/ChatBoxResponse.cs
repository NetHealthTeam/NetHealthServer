using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Response
{
    public class ChatBoxResponse
    {
        public DietResponse DietResponse { get; set; }
        public ExerciseResponse ExerciseResponse { get; set; }

    }
}
