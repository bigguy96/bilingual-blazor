using Microsoft.AspNetCore.Components;

namespace LocalizationApp.Pages
{
    public abstract class BasePage : ComponentBase
    {
       public abstract string PageName { get; } 
    }
}

//https://stackoverflow.com/questions/53786347/multiple-query-string-parameters-in-blazor-routing
//https://blazor-tutorial.net/knowledge-base/50102726/get-current-url-in-a-blazor-component

//https://stackoverflow.com/questions/60161726/find-the-blazor-component-class-corresponding-to-a-given-path
//https://stackoverflow.com/questions/60376576/blazor-how-get-all-route-urls-from-razor-pages-in-blazor-server-side-project
//https://gunnarpeipman.com/aspnet-core-simple-localization/