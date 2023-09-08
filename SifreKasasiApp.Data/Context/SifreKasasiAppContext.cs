using Microsoft.EntityFrameworkCore;
using SifreKasasiApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Data.Context
{
    public class SifreKasasiAppContext : DbContext
    {


        public SifreKasasiAppContext(DbContextOptions<SifreKasasiAppContext> options) : base(options)
        {


        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
