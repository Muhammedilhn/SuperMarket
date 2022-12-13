using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business.Abstract
{
    public interface IShopCartService
    {
        Task<IResponse> SaveAsync(int id);
        Task<IDataResponse<List<ShopCartListDto>>> GetAllAsync();
        Task<IResponse> DeleteAsync(int id);
    }
}
