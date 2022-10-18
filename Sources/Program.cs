using CopyStar.Sources.Model;

namespace CopyStar.Sources
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var app = BuildApp(args);

			app.MapGet("/", () => "Hello World!");

			app.Run();
		}

		private static WebApplication BuildApp(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			DataContext.InitializeConnection(builder.Configuration["Db.ConnectionString"]);

			return builder.Build();
		}
	}
}