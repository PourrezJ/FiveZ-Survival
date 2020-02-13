using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FiveZ.Utils
{
    public static class Config
    {
        private static void loadConfig()
        {
            var baseDir = AltV.Net.Alt.Server.Resource.Path + "\\appsettings.json";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(baseDir, optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            foreach (var dat in configuration.AsEnumerable())
            {
                _settings.Add(dat.Key, dat.Value);
            }
        }

        private static Dictionary<string, object> _settings;
        internal static Dictionary<string, object> Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new Dictionary<string, object>();
                    loadConfig();
                }
                return _settings;
            }
            set
            {
                if (_settings == null) _settings = new Dictionary<string, object>();
                _settings = value;
            }
        }

        public static T GetSetting<T>(string settingName)
        {
            if (Settings != null &&
                Settings.ContainsKey(settingName))
            {
                var val = Settings[settingName];

                T output;

                if (val != null)
                {
                    try
                    {
                        output = (T)Convert.ChangeType(val, typeof(T), CultureInfo.InvariantCulture);
                    }
                    catch (InvalidCastException)
                    {
                        output = (T)Convert.ChangeType(val, typeof(T), CultureInfo.InvariantCulture);
                    }
                    catch (FormatException)
                    {
                        output = (T)Convert.ChangeType(val, typeof(T), CultureInfo.InvariantCulture);
                    }

                    Settings[settingName] = val;
                }
                else
                {
                    output = (T)val;
                }

                return output;
            }

            return default(T);
        }
    }
}