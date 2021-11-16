using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    public class Meal
    {
        [Column("id")]

        public int Id { get; set; }
        [Column("name")]

        public string Name { get; set; }
        [Column("calory")]

        public decimal Calory { get; set; }
        [Column("time_of_day")]
        public short TimeOfDay { get; set; }
        [Column("image_url")]
        public string ImageUrl { get; set; }
        [Column("meal_url")]
        public string MealUrl { get; set; }
        [Column("action_id")]
        public int? ActionId { get; set; }
        [Column("amount")]
        public string Amount { get; set; }

        public List<Diet> Diets { get; set; }
        public Action Action { get; set; }


    }
}
