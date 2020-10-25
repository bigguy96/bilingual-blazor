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
        public string Lang => _twoLetterCulture.Equals("en", StringComparison.OrdinalIgnoreCase) ? "fr" : "en";

        /// <summary>
        /// Read only property, used to populate the text attribute of the language toggle link
        /// Value is defaulted by Template
        /// </summary>
        public string Text => _twoLetterCulture.Equals("en", StringComparison.OrdinalIgnoreCase) ? "Français" : "English";
    }
}