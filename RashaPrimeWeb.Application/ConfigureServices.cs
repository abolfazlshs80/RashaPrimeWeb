using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RashaPrimeWeb.Application.Common;
using RashaPrimeWeb.Application.Mappings;

namespace RashaPrimeWeb.Application
{
 

   


    public static class ApplicationServiceRegistration
    {
        
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            });

            // ثبت Validatorها
            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);

            // اضافه کردن Validation Pipeline Behavior
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
         
        }
    }
}


    


        
   


