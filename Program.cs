using ProjectWebCV.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjectWebCV
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // =========================================================
            // 1) Регистрираме Entity Framework Core + SQL Server
            //    Чете "DefaultConnection" от appsettings.json
            // =========================================================
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // =========================================================
            // 2) Включваме MVC (Controllers + Views)
            // =========================================================
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // =========================================================
            // 3) Грешки — когато не сме в Development
            // =========================================================
            if (!app.Environment.IsDevelopment())
            {
                // Показване на Error.cshtml
                app.UseExceptionHandler("/Home/Error");
            }

            // =========================================================
            // 4) Статични файлове (CSS, JS, images)
            //    ТРЯБВА да е преди UseRouting()
            // =========================================================
            app.UseStaticFiles();

            // MVC Routing middleware
            app.UseRouting();

            // (Не използваме автентикация, но трябва да стои по дизайн)
            app.UseAuthorization();

            // =========================================================
            // 5) Static web assets за Bootstrap, библиотеките и site.css
            // =========================================================
            app.MapStaticAssets();

            // =========================================================
            // 6) Главният MVC маршрут
            //
            //    Контролер по подразбиране: Cv
            //    Действие по подразбиране: Index
            //
            //    Това прави:
            //    /     → CvController.Index()
            //    /Cv   → CvController.Index()
            // =========================================================
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Cv}/{action=Index}/{id?}")
                .WithStaticAssets();

            // Стартираме приложението
            app.Run();
        }
    }
}
