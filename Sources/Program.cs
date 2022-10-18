using CopyStar.Sources.Models.DataBase;

namespace CopyStar.Sources
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = BuildApp(args);
            StartupConfiguration(app);
            RouteEndpoints(app);

            app.Run();
        }

        private static WebApplication BuildApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            DataContext.InitializeConnection(builder.Configuration["Db.ConnectionString"]);

            builder.Services.AddControllersWithViews();

            return builder.Build();
        }

        private static void StartupConfiguration(WebApplication app)
        {
            app.UseStaticFiles();
            app.UseHttpsRedirection();
        }

        private static void RouteEndpoints(WebApplication app)
        {
            app.UseRouting();
            app.MapControllerRoute(name: "default",
                                   pattern: "{Controller=Home}/{Action=Welcome}");

            app.MapControllers();
        }
    }
}
