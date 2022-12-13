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
    public class ShopCartService : IShopCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopCartService(IUnitOfWork unitOfWork, IMapper mapper = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResponse> SaveAsync(int id)
        {
            var shopCartDto = new ShopCartAddDto()
            {
                ProductId = id,
                IsActive = true,
            };
            var shopcart = _mapper.Map<ShopCart>(shopCartDto);
            await _unitOfWork.GetRepository<ShopCart>().AddAsync(shopcart);
            await _unitOfWork.SaveAsync();
            return new Response(ResponseType.Success);
        }
        public async Task<IDataResponse<List<ShopCartListDto>>> GetAllAsync()
        {
            var shopcartList = await _unitOfWork.GetRepository<ShopCart>().GetAllAsync(x => x.IsActive,p=>p.Product);
            var shopCartListDto = _mapper.Map<List<ShopCartListDto>>(shopcartList);
            return new DataResponse<List<ShopCartListDto>>(ResponseType.Success, shopCartListDto);
        }
        public async Task<IResponse> DeleteAsync(int id)
        {
            var shopcart = await _unitOfWork.GetRepository<ShopCart>().GetAsync(x => x.Id == id);
            if (shopcart != null)
            {
                shopcart.IsActive = false;
                await _unitOfWork.GetRepository<ShopCart>().UpdateAsync(shopcart);
                await _unitOfWork.SaveAsync();
                return new Response(ResponseType.Success, "Ürün silme işlemi başarıyla gerçekleştirildi.");
            }
            return new DataResponse<ProductUpdateDto>(ResponseType.NotFound, $"{id} ait veri bulunamadı.");
        }
    }
}
