using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Context;
using NetHealthServer.Data.Entities;
using NetHealthServer.Repo.Abstract;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Concrete
{
    public class ActionRepo : IActionRepo
    {
        private readonly NetHealthDbContext netHealthDbContext;

        public ActionRepo(NetHealthDbContext netHealthDbContext)
        {
            this.netHealthDbContext = netHealthDbContext;
        }
        public async Task<Action> GetActionById(int? id)
        {
           var action = await netHealthDbContext.Actions.FirstOrDefaultAsync(x => x.Id == id);
            return action;
        }
    }
}
