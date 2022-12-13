using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Core.Utilities.Results;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SuperMarket.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<UserLoginDto> _userloginDto;
        public AccountController(IAccountService accountService, IValidator<UserLoginDto> userloginDto)
        {
            _accountService = accountService;
            _userloginDto = userloginDto;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _accountService.GetAsync(userLoginDto);
            if(user.ResponseType == ResponseType.Success)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Data.Id.ToString()));
                claims.Add(new Claim("FirstName", user.Data.FirstName.ToString()));

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Products");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
