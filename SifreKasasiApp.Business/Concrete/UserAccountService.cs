using AutoMapper;
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
    public class UserAccountService : IUserAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public void Add(UserAccountDTO entity)
        {
            var userAccount = mapper.Map<UserAccountDTO, UserAccount>(entity);
            unitOfWork.GetRepository<UserAccount>().Add(userAccount);
            unitOfWork.Save();

        }

        public void Delete(int id)
        {
            unitOfWork.GetRepository<UserAccount>().Delete(id);
            unitOfWork.Save();
        }

        public IEnumerable<UserAccountDTO> GetAllByUserId(int id)
        {
            var userAccountList = unitOfWork.GetRepository<UserAccount>().GetAllByFilter(x => x.UserId == id);
            return mapper.Map<List<UserAccountDTO>>(userAccountList);
        }

        public UserAccountDTO GetById(int id)
        {
            var userAccount = unitOfWork.GetRepository<UserAccount>().GetByFilter(x => x.UserAccountId == id);
            return mapper.Map<UserAccount, UserAccountDTO>(userAccount);
        }

        public void Update(UserAccountDTO entity)
        {
            var userAccount = mapper.Map<UserAccountDTO, UserAccount>(entity);
            unitOfWork.GetRepository<UserAccount>().Update(userAccount);
            unitOfWork.Save();
        }
    }
}
