using System.Data;
using FluentValidation.AspNetCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RashaPrimeWeb.Application.Common;
using RashaPrimeWeb.Domain.Interface;
using RashaPrimeWeb.Infrastructure.Context;
using RashaPrimeWeb.Infrastructure.Implement;

namespace RashaPrimeWeb.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, string con_string)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        services.AddKeyedScoped<ICategoryRepository, DapperCategoryRepository>("Dapper");
        services.AddKeyedScoped<ICategoryRepository, EfCoreCategoryRepository>("EF");
        services.AddKeyedScoped<IUnitOfWork, UnitOfWork>("EF");
        services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
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

        return services;
    }

}