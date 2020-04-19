using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LocalizationApp.Pages
{
    public abstract class BasePage : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }        

        public abstract string PageName { get; }

        protected override async Task OnInitializedAsync()
        {                   
            var uri = new Uri(NavigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
            var currentCulture = uri.Contains("/en/") ? "en" : "fr";
            var alternateCulture = currentCulture.Equals("en") ? "/fr/" : "/en/";

           
            // Get all the components whose base class is basepage
            var routeAttributes = Assembly.GetExecutingAssembly().ExportedTypes
                                  .Where(t => t.IsSubclassOf(typeof(BasePage)))
                                  .Where(x => x.Name.Equals(PageName, StringComparison.CurrentCultureIgnoreCase))
                                  .Select(s => new { RouteAttributes = s.GetCustomAttributes(inherit: true).OfType<RouteAttribute>().SingleOrDefault(s => s.Template.Contains(alternateCulture)) });
            var alternateRoute = routeAttributes?.Single()?.RouteAttributes.Template;

            //https://stackoverflow.com/questions/53786347/multiple-query-string-parameters-in-blazor-routing
            //https://blazor-tutorial.net/knowledge-base/50102726/get-current-url-in-a-blazor-component

            await base.OnInitializedAsync();
        }
    }
}

//https://stackoverflow.com/questions/60161726/find-the-blazor-component-class-corresponding-to-a-given-path
//https://stackoverflow.com/questions/60376576/blazor-how-get-all-route-urls-from-razor-pages-in-blazor-server-side-project
//https://gunnarpeipman.com/aspnet-core-simple-localization/