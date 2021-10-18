using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Context
{
    public class NetHealthDbContext : DbContext
    {
        public NetHealthDbContext( DbContextOptions<NetHealthDbContext> options)
            :base(options)
        {

        }
        

    }
}
