using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonelList.Models
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 4)]
        public string Password { get; set; }
    }
}