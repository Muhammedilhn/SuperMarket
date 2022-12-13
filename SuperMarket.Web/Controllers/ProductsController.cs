using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Extensions;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarket.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(new ProductAddDto());
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProductAddDto productAddDto)
        {
            var response = await _productService.SaveAsync(productAddDto);
            if(response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(productAddDto);
            }
            return RedirectToAction("Index", "Products");
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _productService.GetAsync(id);
            if(response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            var response = await _productService.UpdateAsync(productUpdateDto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(productUpdateDto);
            }
            return RedirectToAction("Index", "Products");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _productService.DeleteAsync(id);
            if (response.ResponseType == ResponseType.NotFound)
                return NotFound();
            if(response.ResponseType == ResponseType.Success)
            {
                return Json(response.ResponseType);
            }
            return RedirectToAction("Index", "Products");
        }
        public IActionResult NotFound()
        {
            return View("NotFound","Home");
        }

    }
}
