using MoneyBookService.Loggers;

namespace MoneyBookService
{
    public static class Program
    {
        static string ServiceName = "MoneyBookService";
        static int ServicePort = 7777;
        static string ServiceUrl = $"http://*:{ServicePort}";

        public static async Task Main(string[] args)
        {
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/web-host?view=aspnetcore-2.1&tabs=aspnetcore2x

            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureLogging((_, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddProvider(new Log4NetProvider());
                })
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(ServiceUrl);
                    webBuilder.CaptureStartupErrors(true);
                    webBuilder.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                    webBuilder.PreferHostingUrls(false);
                });

            Log.Instance.Info($"{ServiceName}");

            bool runAsService = args.Contains("--windows-service");
            Log.Instance.Info(runAsService ?
                "Running as windows service." :
                "Running as console application.");

            if (runAsService)
            {
                hostBuilder.UseWindowsService(o => o.ServiceName = ServiceName);
            }

            Log.Instance.Info($"Listening on {ServiceUrl}.");

            var host = hostBuilder.Build();
            await host.RunAsync();
        }
    }
}