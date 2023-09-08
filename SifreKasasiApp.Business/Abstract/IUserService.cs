using SifreKasasiApp.EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Business.Abstract
{
    public interface IUserService : IGenericService<UserDTO>
    {
        int LoginControl(UserLoginDTO userLoginDTO);
    }
}
