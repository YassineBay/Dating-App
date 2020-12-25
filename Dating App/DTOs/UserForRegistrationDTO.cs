using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.DTOs
{
    public class UserForRegistrationDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="Password must be between 4 and 8")]
        public string Password { get; set; }
    }
}
