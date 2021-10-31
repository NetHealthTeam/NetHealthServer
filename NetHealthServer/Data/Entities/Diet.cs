using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    [Table("Diet")]
    public class Diet
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("name")]

        public string Name { get; set; }
        [Column("week_day")]

        public short WeekDay { get; set; }
        public List<NutritionProgram> NutritionPrograms { get; set; }
        public List<Meal> Meals { get; set; }
    }
}
