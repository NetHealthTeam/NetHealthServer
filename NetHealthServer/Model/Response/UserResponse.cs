using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public short Age { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public short NumberOfMeals { get; set; }
        public short NumberOfGyms { get; set; }
        public decimal AmountOfCalories { get; set; }
        public string ActionName { get; set; }
    }
}
