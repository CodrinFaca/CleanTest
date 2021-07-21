using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleanTest.Web.Areas.Account.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Account_UserName")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Account_Password")]
        public string Password { get; set; }
    }
}
