using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using RashaPrimeWeb.Application.Models.ViewModel.Resource;


    public static class MultiLanguageExtention
    {


        public static IMvcBuilder AddMultiLanguage(this IMvcBuilder builder)
        {
            builder .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, option =>
            {
                option.ResourcesPath = "Resourses";
            }).AddDataAnnotationsLocalization(option =>
            {
                option.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(ShareResource));
            });
            return builder;
        }

        public static IServiceCollection AddCustomLocalization(this IServiceCollection builder)
        {
            builder.AddLocalization(option => option.ResourcesPath = "Resourses");
            return builder;
        }

        public static IApplicationBuilder UseCustomRequestLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("fa-IR"),
                new CultureInfo("en-US")
            };
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("fa-IR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            };
            app.UseRequestLocalization(options);
            return app;
        }
    }

