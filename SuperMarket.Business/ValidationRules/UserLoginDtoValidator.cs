using FluentValidation;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business.ValidationRules
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez").MaximumLength(200);
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez").MaximumLength(200);
          
        }
    }
}
