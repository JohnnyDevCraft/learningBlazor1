using Microsoft.AspNetCore.Blazor.Hosting;

namespace BudgetMaster.Blazor
{
    public class Program
    {
        public static void Main(string[] args = null)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IWebAssemblyHostBuilder CreateHostBuilder(string[] args) =>
            BlazorWebAssemblyHost.CreateDefaultBuilder()
                .UseBlazorStartup<Startup>();
    }
}