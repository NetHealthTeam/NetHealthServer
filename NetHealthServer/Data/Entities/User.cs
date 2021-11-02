using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("fullname")]
        public string FullName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("age")]
        public short Age { get; set; }
        [Column("weight")]
        public decimal Weight { get; set; }
        [Column("height")]
        public decimal Height { get; set; }
        [Column("number_of_meals")]
        public short NumberOfMeals { get; set; }
        [Column("number_of_gyms")]
        public short NumberOfGyms { get; set; }
        [Column("amount_of_calories")]
        public decimal AmountOfCalories { get; set; }
        [Column("nutrition_program_id")]
        public int? NutritionProgramId { get; set; }
        [Column("gym_program_id")]
        public int? GymProgramId { get; set; }
        [Column("action_id")]
        public int? ActionId { get; set; }
        public NutritionProgram NutritProgram { get; set; }
        public GymProgram GymProgram { get; set; }
        public Action Action { get; set; }

    }
}
