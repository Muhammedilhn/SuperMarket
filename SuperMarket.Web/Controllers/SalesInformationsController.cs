using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Web.Controllers
{
    public class SalesInformationsController : Controller
    {
        private readonly ISalesInformationService _salesService;
        private readonly IShopCartService _shopCartService;
        public SalesInformationsController(ISalesInformationService salesService, IShopCartService shopCartService)
        {
            _salesService = salesService;
            _shopCartService = shopCartService;
        }
        public IActionResult Add()
        {
            var shopCartList = _shopCartService.GetAllAsync();
            var totalPrice = new Decimal();
            for (int i = 0; i < shopCartList.Result.Data.Count; i++)
            {
                totalPrice += shopCartList.Result.Data[i].Price;
            }
            var salesdto = new SalesAddDto()
            {
                TotalPrice = totalPrice,
            };
            return View(salesdto);
        }
     
        [HttpPost]
        public async Task<IActionResult> Add(SalesAddDto salesAddDto)
        {
            var result = await _salesService.SaveAsync(salesAddDto);
            if(result.ResponseType == ResponseType.Success)
            {
                return Json(result.ResponseType);
            }
            return RedirectToAction("Index", "Products");
        }
    }
}
