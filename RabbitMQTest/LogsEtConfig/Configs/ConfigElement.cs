using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LogsEtConfig.Configs
{
    public class ConfigElement
    {
        public ConfigElement() { }
        public ConfigElement(string configName, string category, string sourceName, string defaultValue)
        { 
            Name = configName;
            Category = category;
            Sourcename = sourceName;
            DefaultValue = defaultValue;
        }

        public ConfigElement(string configName, string category, string defaultValue)
        {
            Name = configName;
            Category = category;
            Sourcename = "";
            DefaultValue = defaultValue;
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public string Sourcename { get; set; }

        public bool MustBeDefined { get; set; }

        public bool IsUserPreference { get; set; }

        public string RegexPattern { get; set; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(RegexPattern))
                {
                    return true;
                }

                if (string.IsNullOrEmpty(Value))
                {
                    return !MustBeDefined;
                }

                return Regex.IsMatch(Value, RegexPattern);
            }
        }

        public string Value { get; set; }
        public string DefaultValue { get; set; }

        public List<string> HistoryValues;

    }
}
