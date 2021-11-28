using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Request
{
    public class ChatBoxRequest
    {
        
        public string text { get; set; }
    }
}
