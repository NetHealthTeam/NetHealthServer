using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Request
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage ="empty_email")]
        [EmailAddress(ErrorMessage ="email_not_correct")]

        public string Email { get; set; }
        [Required(ErrorMessage ="empty_full_name")]
        public string Fullname { get; set; }
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage ="password_not_correct")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="password_do_not_match")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "empty_gender")]

        public string Gender { get; set; }
        [Required(ErrorMessage = "empty_age")]

        public short Age { get; set; }
        [Required(ErrorMessage = "empty_weight")]

        public decimal Weight { get; set; }
        [Required(ErrorMessage = "empty_height")]

        public decimal Height { get; set; }
        [Required(ErrorMessage = "empty_number_of_meals")]

        public short NumberOfMeals { get; set; }
        [Required(ErrorMessage = "empty_number_of_gyms")]

        public short NumberOfGyms { get; set; }
        [Required(ErrorMessage = "empty_amount_of_calories")]

        public decimal AmountOfCalories { get; set; }
        [Required(ErrorMessage ="action_name_not_found")]
        public string ActionName { get; set; }

    }
}
