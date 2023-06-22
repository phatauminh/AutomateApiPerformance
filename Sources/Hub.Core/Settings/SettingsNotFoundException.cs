using System;

namespace Hub.Core.Settings
{
    public class SettingsNotFoundException : Exception
    {
        public SettingsNotFoundException()
        {
        }

        public SettingsNotFoundException(string configurationType)
            : base($"Configuration section for {configurationType} was not found. Please add the section.")
        {
        }

        public SettingsNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
