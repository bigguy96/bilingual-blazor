using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LocalizationApp.Pages
{
    public abstract class BasePage : ComponentBase
    {
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        public abstract string PageName { get;  }

        protected override async Task OnInitializedAsync()
        {
            var culture = CultureInfo.CurrentCulture.Name;
            var uri = new Uri(navigationManager.Uri).GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
            var query = $"?culture={Uri.EscapeDataString(culture)}&" + $"redirectionUri={Uri.EscapeDataString(uri)}";
            var path = "/Culture/SetCulture" + query;

            var pageTypeList = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(t => t.GetCustomAttribute(typeof(RouteAttribute)) != null);

            // Get all the components whose base class is ComponentBase
            var components = Assembly.GetExecutingAssembly()
                                   .ExportedTypes
                                   .Where(t =>
                                  t.IsSubclassOf(typeof(BasePage)));

            //var t = PageName;

            foreach (var component in components)
            {
                // Print the name (Type) of the Component
                Console.WriteLine(component.ToString());

                // Now check if this component contains the Authorize attribute
                var allAttributes = component.GetCustomAttributes(inherit: true);

                var authorizeDataAttributes = allAttributes.OfType<RouteAttribute>().ToArray();

                //// If it does, show this to us... 
                foreach (var authorizeData in authorizeDataAttributes)
                {

                    Console.WriteLine(authorizeData.ToString());
                }
            }


                base.OnInitializedAsync();
        }
    }
}

//https://stackoverflow.com/questions/60161726/find-the-blazor-component-class-corresponding-to-a-given-path
