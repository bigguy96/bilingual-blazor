using System.Collections.Generic;

namespace LocalizationApp.Entities
{
    public class MenuLink : Link
    {
        public List<SubLink> SubLinks { get; set; }
    }
}