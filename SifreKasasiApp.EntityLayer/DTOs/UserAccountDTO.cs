using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.EntityLayer.DTOs
{
    public class UserAccountDTO
    {
        public int UserAccountId { get; set; }
        public int UserId { get; set; }
        public string WebSiteName { get; set; }
        public string UserNameForWebSite { get; set; }
        public string PasswordForWebSite { get; set; }
    }
}
