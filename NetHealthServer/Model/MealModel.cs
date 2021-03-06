using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model
{
    public class MealModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
       

        public decimal CaloryPerPorsion { get; set; }
        
        public short TimeOfDay { get; set; }
       
        public string ImageUrl { get; set; }
        
        public string MealUrl { get; set; }
        public decimal Portion { get; set; }

    }
}
