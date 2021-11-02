using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Abstract
{
   public interface IActionRepo
    {
        public Task<NetHealthServer.Data.Entities.Action> GetActionById(int? id);
    }
}
