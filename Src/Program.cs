using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Carsales.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseWebRoot(Directory.GetCurrentDirectory() + "\\public")
                .Build();

            host.Run();
        }
    }
    
}