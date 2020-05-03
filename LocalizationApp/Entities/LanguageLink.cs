using System;
using System.Threading;

namespace LocalizationApp.Entities
{
    public class LanguageLink  
    {
        private readonly string _twoLetterCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;

        /// <summary>
        /// URL to be used for the language toggle
        /// Set/built by Template
        /// Can be set by application programmatically
        /// </summary>
        public string Href { get; set; }

        /// <summary>
        /// Read only property, used to populate the Lang attribute of the language toggle link
        /// Value is defaulted by Template
        /// </summary>
        public string Lang
        {
            get
            {
                if (_twoLetterCulture.Equals("en", StringComparison.OrdinalIgnoreCase))
                {
                    return "fr";
                }
                return "en";
            }
        }

        /// <summary>
        /// Read only property, used to populate the text attribute of the language toggle link
        /// Value is defaulted by Template
        /// </summary>
        public string Text
        {
            get
            {
                if (_twoLetterCulture.Equals("en", StringComparison.OrdinalIgnoreCase))
                {
                    return "Français";
                }
                return "English";
            }
        }

    }
}