using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SifreKasasiApp.Business.Abstract;
using SifreKasasiApp.Data.UnitOfWorks;
using SifreKasasiApp.EntityLayer.DTOs;
using SifreKasasiApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SifreKasasiApp.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Add(UserDTO entity)
        {
            User user = new User();
            user = mapper.Map<UserDTO, User>(entity);
            user.Password = PasswordHash(entity.Password);
            unitOfWork.GetRepository<User>().Add(user);
            unitOfWork.Save();

        }

        public void Delete(int id)
        {
            unitOfWork.GetRepository<User>().Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<UserDTO> GetAllByUserId(int id)
        {
            var userList = unitOfWork.GetRepository<User>().GetAllByFilter(null);
            return mapper.Map<List<UserDTO>>(userList);
        }

        //public UserDTO GetByFilter(int id)
        //{
        //    var user = unitOfWork.GetRepository<User>().GetByFilter(x=>x.UserId==id);
        //    return mapper.Map<User, UserDTO>(user);
        //}

        public UserDTO GetById(int id)
        {
            var user = unitOfWork.GetRepository<User>().GetByFilter(x => x.UserId == id);
            return mapper.Map<User, UserDTO>(user);
        }

        public int LoginControl(UserLoginDTO userLoginDTO)
        {
            var user = unitOfWork.GetRepository<User>().GetByFilter(x => x.UserName == userLoginDTO.UserName);

            if (user != null)
            {
                var hashedPassword = PasswordHash(userLoginDTO.Password);

                if (user.Password.Equals(hashedPassword))
                {
                    return user.UserId;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public void Update(UserDTO entity)
        {
            User user = new User();
            user = mapper.Map<UserDTO, User>(entity);
            unitOfWork.GetRepository<User>().Update(user);
            unitOfWork.Save();
        }
        private string PasswordHash(string password)
        {
            byte[] salt = new byte[1];
            salt[0] = 00000000;
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8
                ));
            return hashedPassword;
        }
    }
}
