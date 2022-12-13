using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Concrete;
using SuperMarket.Business.ValidationRules;
using SuperMarket.Data.Contexts;
using SuperMarket.Data.Repositories.Abstract;
using SuperMarket.Data.Repositories.Concrete;
using SuperMarket.Data.UnitOfWorks.Abstract;
using SuperMarket.Data.UnitOfWorks.Concrete;
using SuperMarket.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Business.Extensions
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SuperMarket.Data"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IShopCartService,ShopCartService>();
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<ISalesInformationService, SalesInformationService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

       
            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();
            services.AddTransient<IValidator<UserLoginDto>, UserLoginDtoValidator>();

            return services;
        }
    }
}
