using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarketWebsite.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="ErrorMessage =Please enter email address")]
        [EmailAddress]
        [Display(Name ="Registered email address")]
        public string Email { get; set; }


        public bool emailSent { get; set; }
    }
}
