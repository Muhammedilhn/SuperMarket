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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductAddDto> _productAddDto;
        private readonly IValidator<ProductUpdateDto> _productUpdateDto;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper = null, IValidator<ProductAddDto> productAddDto = null, IValidator<ProductUpdateDto> productUpdateDto = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productAddDto = productAddDto;
            _productUpdateDto = productUpdateDto;
        }

        public async Task<IDataResponse<List<ProductListDto>>> GetAllAsync()
        {
            var productList = await _unitOfWork.GetRepository<Product>().GetAllAsync(x => x.IsActive);
            var productListDto = _mapper.Map<List<ProductListDto>>(productList);
            return new DataResponse<List<ProductListDto>>(ResponseType.Success, productListDto);
        }
        public async Task<IDataResponse<ProductUpdateDto>> GetAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x=>x.Id == id && x.IsActive);
            var productDto = _mapper.Map<ProductUpdateDto>(product);
            if (product != null)
            {
                return new DataResponse<ProductUpdateDto>(ResponseType.Success, productDto);
            }
            return new DataResponse<ProductUpdateDto>(ResponseType.NotFound, $"{id} ye ait veri bulunamadı");
        }
        public async Task<IResponse> SaveAsync(ProductAddDto productAddDto)
        {
            var validationResult = _productAddDto.Validate(productAddDto);
            if (validationResult.IsValid)
            {
                var product = _mapper.Map<Product>(productAddDto);
                await _unitOfWork.GetRepository<Product>().AddAsync(product);
                await _unitOfWork.SaveAsync();
                return new Response(ResponseType.Success,"Ürün ekleme işlemi başarıyla gerçekleştirildi.");
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }
                return new Response(ResponseType.ValidationError, errors);
            }
        }
        public async Task<IResponse> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var validationResult = _productUpdateDto.Validate(productUpdateDto);
            if (validationResult.IsValid)
            {
                var product = _mapper.Map<Product>(productUpdateDto);
                await _unitOfWork.GetRepository<Product>().UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                return new DataResponse<ProductUpdateDto>(ResponseType.Success, productUpdateDto);
            }
            else
            {
                List<CustomValidationError> errors = new();
                foreach (var error in validationResult.Errors)
                {
                    errors.Add(new()
                    {
                        ErrorMessage = error.ErrorMessage,
                        PropertyName = error.PropertyName
                    });
                }
                return new Response(ResponseType.ValidationError, errors);
            }
        }
        public async Task<IResponse> DeleteAsync(int id)
        {
            var product = await _unitOfWork.GetRepository<Product>().GetAsync(x => x.Id == id);
            if (product != null)
            {
                product.IsActive = false;
                await _unitOfWork.GetRepository<Product>().UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                return new Response(ResponseType.Success, "Ürün silme işlemi başarıyla gerçekleştirildi.");
            }
            return new DataResponse<ProductUpdateDto>(ResponseType.NotFound, $"{id} ait veri bulunamadı.");
        }
    }
}
