using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalizationApp.Pages
{
    public class TestBase : BasePage
    {
        public override string PageName { get => "test";  }

        [Inject]
        public IStringLocalizer<Test> localizer { get; set; }
    }
}
