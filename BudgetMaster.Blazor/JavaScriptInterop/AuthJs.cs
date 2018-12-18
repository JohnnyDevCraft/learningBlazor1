using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BudgetMaster.Blazor.JavaScriptInterop
{
    public static class AuthJs
    {
        public static Task ShowLock()
        {
            return JSRuntime.Current.InvokeAsync<object>("functions.showLock");
        }

        [JSInvokable]
        public static Task RegisterUser(string token, string profile)
        {
            
            Console.WriteLine(token);
            Console.WriteLine(profile);
            
            return Task.Run(() =>
            {
                
            });

        }
    }
}