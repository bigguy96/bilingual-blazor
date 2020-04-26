using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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
