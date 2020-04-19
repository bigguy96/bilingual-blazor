using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LocalizationApp.Pages
{
    public class DefTopBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject] 
        public IStringLocalizer<DefTop> Localizer { get; set; }

        //protected override async Task OnInitializedAsync()
        //{
        //    var uri = new Uri(NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
        //    var currentCulture = uri.Contains("/en/") ? "en" : "fr";
        //    var alternateCulture = currentCulture.Equals("en") ? "/fr/" : "/en/";

        //    // get @page values from a page and get alternate language.
        //    var routeAttributes = Assembly.GetExecutingAssembly().ExportedTypes
        //              .Where(t => t.IsSubclassOf(typeof(BasePage)))
        //              .Where(x => x.Name.Length > 1)
        //              .Select(s => new { RouteAttributes = s.GetCustomAttributes(inherit: true).OfType<RouteAttribute>().SingleOrDefault(s => s.Template.Contains(alternateCulture)) });

        //    var alternateRoute = routeAttributes?.Single(s => s.RouteAttributes != null)?.RouteAttributes.Template;

        //    await JSRuntime.InvokeVoidAsync("exampleJsFunctions.appTop",
        //        Localizer["ApplicationName"], currentCulture, alternateRoute, Localizer["AlternateLanguage"]);

        //    await base.OnInitializedAsync();
        //}

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var uri = new Uri(NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
                var currentCulture = uri.Contains("/en/") ? "en" : "fr";
                var alternateCulture = currentCulture.Equals("en") ? "/fr/" : "/en/";

                // get @page values from a page and get alternate language.
                var routeAttributes = Assembly.GetExecutingAssembly().ExportedTypes
                          .Where(t => t.IsSubclassOf(typeof(BasePage)))
                          .Where(x => x.Name.Length > 1)
                          .Select(s => new { RouteAttributes = s.GetCustomAttributes(inherit: true).OfType<RouteAttribute>().SingleOrDefault(s => s.Template.Contains(alternateCulture)) });

                var alternateRoute = routeAttributes?.Single(s => s.RouteAttributes != null)?.RouteAttributes.Template;

                await JSRuntime.InvokeVoidAsync("exampleJsFunctions.appTop",
                    Localizer["ApplicationName"], currentCulture, alternateRoute, Localizer["AlternateLanguage"]);
            }

            await base.OnAfterRenderAsync(firstRender);
        }
    }
}