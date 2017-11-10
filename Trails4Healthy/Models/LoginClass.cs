using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trails4Healthy.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage = "Username is required")] // make the field required
        [Display(Name = "Username")]
        public string username { get; set; }


        [Required(ErrorMessage = "Pass is required")]
        [Display(Name = "Password")]
        [RegularExpression(@"\w{6}",ErrorMessage ="Tem de ter pelo menos 6 carateres")]
         public string pass { get; set; }
    }
}
