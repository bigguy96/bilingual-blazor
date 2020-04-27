using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace LocalizationApp.Pages
{
    public class TestBase : ComponentBase
    {
        //public override string PageName { get => "test"; }

        [Inject]
        public IStringLocalizer<Test> localizer { get; set; }

        protected override void OnInitialized()
        {
            var c = CultureInfo.CurrentCulture.Name;

            //base.OnInitialized();
        }
    }
}
