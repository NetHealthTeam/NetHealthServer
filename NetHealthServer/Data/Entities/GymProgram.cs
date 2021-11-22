using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    [Table("Gym_program")]
    public class GymProgram
    {
        public GymProgram()
        {
            Workouts = new List<Workout>();
        }
        
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
