using System;
using System.Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RashaPrimeWeb.Application.Common;

using RashaPrimeWeb.Domain.Interface;
using RashaPrimeWeb.Infrastructure.Context;
using RashaPrimeWeb.Infrastructure.Implement;
using RashaPrimeWeb.Infrastructure.Implement.Category;
using SharedUtilities.Identity;

namespace RashaPrimeWeb.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string con_string)
    {        //services.AddKeyedScoped<ICategoryRepository, DapperCategoryRepository>("Dapper");
        //services.AddKeyedScoped<ICategoryRepository, EfCoreCategoryRepository>("EF");

        //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICategoryRepository, DapperCategoryRepository>();

        // Add DbContext for EF Core
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(con_string));

        services.AddTransient<IDbConnection>(provider =>
        {
            var connectionString = con_string;
            return new SqlConnection(connectionString);
        });

        // Add FluentValidation
        services.AddFluentValidationAutoValidation(); // اعتبارسنجی خودکار سمت سرور
        services.AddFluentValidationClientsideAdapters(); // اعتبارسنجی سمت کلاینت (اختیاری)

        //Add Identity


        #region AddIdentity

        services.AddIdentity<UserApplication, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            //فارسی سازی ارور 
            .AddErrorDescriber<CustomIdentityError>();


        services.Configure<IdentityOptions>(options =>
        {
            // تنظیمات اعتبارسنجی رمز عبور
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 3;

            // تنظیمات قفل کردن حساب کاربری
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;

            // تنظیمات کوکی‌ها و احراز هویت
            options.SignIn.RequireConfirmedEmail = false;
        });
        services.AddScoped<RoleManager<IdentityRole>>();
        #endregion

        return services;
    }

}