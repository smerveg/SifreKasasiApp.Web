using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.EntityLayer.Entities
{
    [Index(nameof(User.UserName),IsUnique = true)]
    public class User
    {
        public int UserId { get; set; }
        
        [StringLength(50)]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }

        //NP
        public ICollection<UserAccount> UserAccounts { get; set; }
    }
}
