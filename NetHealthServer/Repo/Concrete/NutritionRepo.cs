using Microsoft.EntityFrameworkCore;
using NetHealthServer.Data.Context;
using NetHealthServer.Data.Entities;
using NetHealthServer.Errors;
using NetHealthServer.Repo.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Repo.Concrete
{
    public class NutritionRepo : INutritionRepo
    {
        private readonly NetHealthDbContext netHealthDbContext;

        public NutritionRepo(NetHealthDbContext netHealthDbContext)
        {
            this.netHealthDbContext = netHealthDbContext;
        }
        public async Task<NutritionProgram> GetNutritionProgram(int? actionId)
        {
            
            var nutritionProgram = await netHealthDbContext.NutritionPrograms.OrderByDescending(x=>x.Id).FirstOrDefaultAsync(x=>x.ActionId==actionId);
            if (nutritionProgram == null)
            {
                throw new CustomError("nutrition_program_not_found");
            }
            return nutritionProgram;
        }
    }
}
