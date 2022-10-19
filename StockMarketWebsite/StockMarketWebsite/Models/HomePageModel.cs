using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Domains;
namespace StockMarketWebsite.Models
{
    public class HomePageModel
    {
        public IEnumerable<ApplicationUser> UserData { get; set; }


        public UserModel user { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }


        public ApplicationUser OneUser { get; set; }



        public TbRequest item { get; set; }




    }
}
