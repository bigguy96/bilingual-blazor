using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace LocalizationApp.Utils
{
    public static class JSInterop
    {
        [JSInvokable]
        public static Task Redirect(string url)
        {
            //StateHasChanged();

            NavigationManager.NavigateTo(url, true);
            

            //var message = "Hello from C#";
            return Task.FromResult(true);
        }

        private static NavigationManager NavigationManager { get; set; }
    }
}
