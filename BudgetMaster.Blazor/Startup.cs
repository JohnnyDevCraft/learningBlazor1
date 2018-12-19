using Blazored.Storage;
using BudgetMaster.Blazor.Abstractions;
using BudgetMaster.Blazor.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetMaster.Blazor
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalStorage();
            services.AddSingleton<IAuthenticationService, AuthService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}