﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.EntityLayer.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
    }
}
