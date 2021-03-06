using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SocketApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseKestrel(options =>
				{
					// TCP 8007
					options.ListenLocalhost(8007, builder =>
					{
						builder.UseConnectionHandler<MyEchoConnectionHandler>();
					});

					// HTTP 5000
					options.ListenLocalhost(5000);

					// HTTPS 5001
					options.ListenLocalhost(5001, builder =>
					{
						builder.UseHttps();
					});
				})
				.UseStartup<Startup>();
	}
}
