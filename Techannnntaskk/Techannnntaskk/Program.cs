using Microsoft.EntityFrameworkCore;
using Techannnntaskk.DataAccesLayer;
namespace Techannnntaskk
{
    public class Program
    {
        public static void Main (string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<Test>();
            builder.Services.AddScoped<Test2>();
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDbContext<TechanDbContext>(options => options.UseSqlServer("Server=localhost\\SQLEXPRESS;;Database=Techan;Trusted_Connection=true;TrustServerCertificate=true"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}


