using BudgetMaster.Blazor.Models;

namespace BudgetMaster.Blazor.Abstractions
{
    public interface IAuthenticationService
    {
        void Authenticate();
        void HandelAuthentication();
        
        UserProfileModel CurrentUser { get; }
    }
}