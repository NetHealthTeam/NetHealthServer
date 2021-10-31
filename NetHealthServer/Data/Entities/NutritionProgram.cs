using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    [Table("Nutrition_program")]
    public class NutritionProgram
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("name")]

        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Diet> Diets { get; set; }
    }
}
