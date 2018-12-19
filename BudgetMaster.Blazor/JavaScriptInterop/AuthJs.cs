using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BudgetMaster.Blazor.JavaScriptInterop
{
    public static class AuthJs
    {
        public static Task ShowLock()
        {
            return JSRuntime.Current.InvokeAsync<object>("authFunctions.beginAuth");
        }

        public static Task SetSessionItem(string name, string value)
        {
            return JSRuntime.Current.InvokeAsync<object>("authFunctions.setSessionItem", name, value);
        }

        public static Task<string> getSessionItem(string name)
        {
            return JSRuntime.Current.InvokeAsync<string>("authFunctions.getSessionItem", name);
        }

        public static Task HandleAuthentication()
        {
            return JSRuntime.Current.InvokeAsync<object>("authFunctions.handleAuth");
        }
        
    }
}