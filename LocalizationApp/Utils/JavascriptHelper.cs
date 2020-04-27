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
        public static HtmlString GetAppTop( string url, string applicationName)
        {

            var currentCulture = url.Contains("/en/") ? "en" : "fr";
            var alternateCulture = currentCulture.Equals("en") ? "/fr/" : "/en/";

            // get @page values from a page and get alternate language.
            var routeAttributes = Assembly.GetExecutingAssembly().ExportedTypes
                      .Where(t => t.IsSubclassOf(typeof(ComponentBase)))
                      .Where(x => x.Name.Length > 1)
                      .Select(s => new { RouteAttributes = s.GetCustomAttributes(inherit: true).OfType<RouteAttribute>().SingleOrDefault(s => s.Template.Contains(alternateCulture)) });

            var alternateRoute = routeAttributes?.Single(s => s.RouteAttributes != null)?.RouteAttributes.Template;

            var appTop = new AppTop
            {
                AppName = new List<Link> { new Link { Href = "#", Text = applicationName } },
                LngLinks = new List<LanguageLink> { new LanguageLink { Href = alternateRoute } },
                MenuLinks = new List<MenuLink> { new MenuLink { Href = "#", Text = "Nav 1" }, new MenuLink { Href = "#", Text = "Nav 2" }, new MenuLink { Href = "#", Text = "Nav 3" }, new MenuLink { Href = "#", Text = "Nav 4" } }

            };

            var json = JsonSerializationHelper.SerializeToJson(appTop);

            return json;
        }
    }
}