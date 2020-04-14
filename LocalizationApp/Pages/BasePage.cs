using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Localization;
using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components.IUriHelper;

namespace LocalizationApp.Pages
{
    public abstract class BasePage : ComponentBase
    {
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        //protected UriHelper uriHelper

        public abstract string PageName { get; }

        protected override async Task OnInitializedAsync()
        {
            //var currentCulture = CultureInfo.CurrentCulture.Name;           
            var uri = new Uri(navigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
            var currentCulture = uri.Contains("/en/") ? "en" : "fr";
            var alternateCulture = currentCulture.Equals("en") ? "/fr/" : "/en/";
            var query = $"?culture={Uri.EscapeDataString(currentCulture)}&" + $"redirectionUri={Uri.EscapeDataString(uri)}";
            //var path = "/Culture/SetCulture" + query;

            //var cultureInfo = new CultureInfo(currentCulture);
            //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            //var cc = CultureInfo.CurrentCulture.Name;

            // Get all the components whose base class is basepage
            var routeAttributes = Assembly.GetExecutingAssembly().ExportedTypes
                                  .Where(t => t.IsSubclassOf(typeof(BasePage)))
                                  .Where(x => x.Name.Equals(PageName, StringComparison.CurrentCultureIgnoreCase))
                                  .Select(s => new { RouteAttributes = s.GetCustomAttributes(inherit: true).OfType<RouteAttribute>().SingleOrDefault(s => s.Template.Contains(alternateCulture)) });
            var alternateRoute = routeAttributes?.Single()?.RouteAttributes.Template;

            navigationManager.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
            //navigationManager.NavigateTo(uri);
            //StateHasChanged();           


            await base.OnInitializedAsync();
        }

        

        //protected override Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender)
        //    {
        //        var uri = new Uri(navigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
        //        var currentCulture = uri.Contains("/en/") ? "en" : "fr";                
        //        var query = $"?culture={Uri.EscapeDataString(currentCulture)}&" + $"redirectionUri={Uri.EscapeDataString(uri)}";
        //        var path = "/Culture/SetCulture" + query;

        //        navigationManager.NavigateTo(path, forceLoad: true);
        //    }

        //    return base.OnAfterRenderAsync(firstRender);
        //}

        //private async Task DoNothing()
        //{
        //    await Task.FromResult(0);
        //}
    }    
}

//https://stackoverflow.com/questions/60161726/find-the-blazor-component-class-corresponding-to-a-given-path
//https://stackoverflow.com/questions/60376576/blazor-how-get-all-route-urls-from-razor-pages-in-blazor-server-side-project
//https://gunnarpeipman.com/aspnet-core-simple-localization/
