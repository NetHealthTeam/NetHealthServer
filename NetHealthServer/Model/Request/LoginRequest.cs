using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetHealthServer.Model.Request
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "empty_email")]
        [EmailAddress(ErrorMessage = "email_not_correct")]
        public string Email { get; set; }
        [Required(ErrorMessage ="empty_password")]
        public string Password { get; set; }
    }
}
