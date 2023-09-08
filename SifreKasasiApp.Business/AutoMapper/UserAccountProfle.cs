using AutoMapper;
using SifreKasasiApp.EntityLayer.DTOs;
using SifreKasasiApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Business.AutoMapper
{
    public class UserAccountProfile : Profile
    {
        public UserAccountProfile()
        {
            CreateMap<UserAccount, UserAccountDTO>().ReverseMap();
        }
    }
}
