using LocalizationApp.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Html;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LocalizationApp.Utils
{
    public static class JavascriptHelper
    {
        public static HtmlString GetAppTop(string url, string applicationName)
        {
            var currentCulture = url.Contains("/en/") ? "en" : "fr";
            var alternateCulture = currentCulture.Equals("en") ? "/fr/" : "/en/";

            //https://stackoverflow.com/questions/60376576/blazor-how-get-all-route-urls-from-razor-pages-in-blazor-server-side-project
            //get @page values from a page and get alternate language.
            var routeAttributes = Assembly.GetExecutingAssembly().ExportedTypes
                     .Where(t => t.IsSubclassOf(typeof(ComponentBase)))
                     .Where(x => x.Name.Length > 1)
                     .Select(s => new { RouteAttributes = s.GetCustomAttributes(inherit: true).OfType<RouteAttribute>() });
            
            //get route values for the current page and get the alternate language.            
            var alternateRoute = routeAttributes
                .SingleOrDefault(x => x.RouteAttributes.Any(a => a.Template.Contains(url)))?.RouteAttributes
                .SingleOrDefault(s => s.Template.Contains(alternateCulture))?.Template;

            var appTop = new AppTop
            {
                AppName = new List<Link> { new Link { Href = "#", Text = applicationName } },
                LngLinks = new List<LanguageLink> { new LanguageLink { Href = alternateRoute } },
                MenuLinks = new List<MenuLink> { new MenuLink { Href = "#", Text = "Nav 1" }, new MenuLink { Href = "#", Text = "Nav 2" }, new MenuLink { Href = "#", Text = "Nav 3" }, new MenuLink { Href = "#", Text = "Nav 4" } }

            };

            return JsonSerializationHelper.SerializeToJson(appTop);
        }
    }
}