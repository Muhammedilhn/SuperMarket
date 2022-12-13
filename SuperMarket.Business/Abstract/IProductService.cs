using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResponse<List<ProductListDto>>> GetAllAsync();
        Task<IDataResponse<ProductUpdateDto>> GetAsync(int id);
        Task<IResponse> SaveAsync(ProductAddDto productAddDto);
        Task<IResponse> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<IResponse> DeleteAsync(int id);
    }
}
