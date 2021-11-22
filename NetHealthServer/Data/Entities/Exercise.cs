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
        [Column("calory_per_hour")]
        public string CaloryPerHour { get; set; }
        [Column("image_url")]
        public string ImageUrl { get; set; }
        public List<Workout> Workouts { get; set; }
    }
}
