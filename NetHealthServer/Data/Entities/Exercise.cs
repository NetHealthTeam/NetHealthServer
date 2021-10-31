using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    [Table("Exercise")]
    public class Exercise
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("calory")]

        public decimal Calory { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
