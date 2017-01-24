using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DotNetGroupTalk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var config = new ConfigurationBuilder()
            //         .AddCommandLine(args)
            //         .AddEnvironmentVariables(prefix:"ASPNETCORE_")
            //         .Build();
            var host = new WebHostBuilder()
                    .UseUrls("http://*:5000")
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();

             host.Run();
        }
    }
}
