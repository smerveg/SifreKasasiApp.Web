using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.EntityLayer.Entities
{
    public class UserAccount
    {
        public int UserAccountId { get; set; }
        [Required]
        public string WebSiteName { get; set; }
        [Required]
        public string UserNameForWebSite { get; set; }
         [Required]
        public string PasswordForWebSite { get; set; }

        //NP

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
