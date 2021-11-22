using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Response
{
    public class GymResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string CaloriePerHour { get; set; }
        public decimal Duration { get; set; }
        public int Weekday { get; set; }
    }
}
