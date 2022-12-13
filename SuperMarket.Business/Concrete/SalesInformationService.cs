using AutoMapper;
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
    public class SalesInformationService : ISalesInformationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesInformationService(IUnitOfWork unitOfWork, IMapper mapper = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResponse> SaveAsync(SalesAddDto salesAddDto)
        {
            var sales = _mapper.Map<SalesInformation>(salesAddDto);
            var result = await _unitOfWork.GetRepository<SalesInformation>().AddAsync(sales);
            var shopcarts = _unitOfWork.GetRepository<ShopCart>().GetAllAsync(x=>x.IsActive);
            await _unitOfWork.SaveAsync();
            for (int i = 0; i < shopcarts.Result.Count; i++)
            {
                shopcarts.Result[i].SalesInformationId = sales.Id;
                shopcarts.Result[i].IsActive = false;
                await _unitOfWork.GetRepository<ShopCart>().UpdateAsync(shopcarts.Result[i]);
                await _unitOfWork.SaveAsync();
            }
       
            return new Response(ResponseType.Success, "Alışveriş başarıyla tamamlandı.");
        }
    }
}
