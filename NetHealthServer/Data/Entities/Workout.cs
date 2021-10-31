using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    public class Workout
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]


        public string Name { get; set; }
        public List<GymProgram> GymPrograms { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
