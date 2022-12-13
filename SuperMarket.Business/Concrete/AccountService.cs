using AutoMapper;
using FluentValidation;
using SuperMarket.Business.Abstract;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Data.UnitOfWorks.Abstract;
using SuperMarket.Entities.Dtos;
using SuperMarket.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResponse<UserLoginDto>> GetAsync(UserLoginDto userLoginDto)
        {
            var user = await _unitOfWork.GetRepository<User>().GetAsync(x=>x.FirstName == userLoginDto.FirstName && x.Password == userLoginDto.Password); 
            if(user != null)
            {
                var userDto = _mapper.Map<UserLoginDto>(user);
                if (userDto != null)
                {
                    return new DataResponse<UserLoginDto>(ResponseType.Success, userDto);
                }
            }
            return new DataResponse<UserLoginDto>(ResponseType.Error, "Kullanıcı Bulunamadı");
        }
    }
}
