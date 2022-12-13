using FluentValidation;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business.ValidationRules
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı alanı boş geçilemez.").MaximumLength(200);
            RuleFor(x => x.ProductType).NotEmpty().WithMessage("Ürün türü alanı boş Geçilemez.");
            RuleFor(x => x.StockCount).GreaterThan(0).WithMessage("Stok miktari 0 den buyuk olmali");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez");
        }
    }
}
