using BudgetMaster.Blazor.Abstractions;
using BudgetMaster.Blazor.Models;

namespace BudgetMaster.Blazor.Services
{
    public class AuthService: IAuthenticationService
    {
        public void Authenticate()
        {
            JavaScriptInterop.AuthJs.ShowLock();
        }

        public void HandelAuthentication()
        {
            JavaScriptInterop.AuthJs.HandleAuthentication();
            JavaScriptInterop.AuthJs.LoadProfile();
            var username = JavaScriptInterop.AuthJs.GetCurrentUserName().Result;
            var email = JavaScriptInterop.AuthJs.GetCurrentUserEmail().Result;
            CurrentUser = new UserProfileModel()
            {
                UserName = username,
                EmailAddress = email
            };
        }

        public UserProfileModel CurrentUser { get; private set; }
    }
}