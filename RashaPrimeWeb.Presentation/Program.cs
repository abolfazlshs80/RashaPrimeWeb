using RashaPrimeWeb.Application;
using RashaPrimeWeb.Infrastructure;

namespace RashaPrimeWeb.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorOptions(options =>
            {
                // اضافه کردن مسیرهای سفارشی برای جست‌وجوی Partial View
                options.ViewLocationFormats.Add("/Views/Shared/Partial/MainLayout/{0}.cshtml");
            }); ;

            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterInfrastructureServices(connection);
            var app = builder.Build();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication(); // قبل از UseAuthorization قرار دارد
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
