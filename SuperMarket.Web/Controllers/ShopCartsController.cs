using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using SuperMarket.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Web.Controllers
{
    public class ShopCartsController : Controller
    {
        private readonly IShopCartService _shopCartService;
        private readonly ICurrentUserService _currentUserService;
        public ShopCartsController(IShopCartService shopCartService, ICurrentUserService currentUserService = null)
        {
            _shopCartService = shopCartService;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Index()
        {
            var shopcarts = await _shopCartService.GetAllAsync();
            return View(shopcarts.Data);
        }
        public async Task<IActionResult> Add(int id)
        {
            var result = await _shopCartService.SaveAsync(id);
            if (result.ResponseType == ResponseType.Success)
            {
                return Json(result.ResponseType);
            }
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _shopCartService.DeleteAsync(id);
            if (response.ResponseType == ResponseType.NotFound)
                return NotFound();
            if (response.ResponseType == ResponseType.Success)
            {
                return Json(response.ResponseType);
            }
            return RedirectToAction("Index", "ShopCarts");
        }
        public IActionResult NotFound()
        {
            return View("NotFound", "Home");
        }
    }
}
