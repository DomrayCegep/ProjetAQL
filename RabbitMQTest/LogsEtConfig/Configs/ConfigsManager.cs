using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LogsEtConfig.Configs
{
    public class ConfigsManager
    {
        public ConfigsManager() 
        {
            ConfigElements = new List<ConfigElement>();
        }

        public void AddConfigElement(ConfigElement element)
        {
            ConfigElement? ce = ConfigElements.Where(e => e.Name == element.Name).FirstOrDefault();
            if (ce == null)
            {
                ConfigElements.Add(element);
            }
             else
            {
                ce.Value = element.Value;
                ce.Sourcename = element.Sourcename;
            }

        }

        public void AddConfigElementsFromConcreteObject(object config)
        {
            ConfigElement ce;

            List<string> elements = config.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(ConfigElement))
                .Select(p => p.Name)
                .ToList();


            foreach (string e in elements)
            {
                ce = new ConfigElement
                {
                    Name = e,
                    Value = "",
                    Sourcename = config.GetType().Name,
                    Category = "ConcreteConfig",
                    MustBeDefined = true
                };

                AddConfigElement(ce);
            }
        }

        public void LoadConfigs(string[] args)
        {
            ConfigElement ce;

            ConfigurationManager.AppSettings.AllKeys.ToList().ForEach(key =>
            {
                var value = ConfigurationManager.AppSettings[key];
                ce =new ConfigElement
                {
                    Name = key,
                    Value = value,
                    Sourcename = "AppSettings",
                    Category = "General",
                    MustBeDefined = false
                };

                AddConfigElement(ce);
            });

            ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().ToList().ForEach(connStr =>
            {
                ce = new ConfigElement
                {
                    Name = connStr.Name,
                    Value = connStr.ConnectionString,
                    Sourcename = "ConnectionStrings",
                    Category = "Database",
                    MustBeDefined = false
                };
                AddConfigElement(ce);
            });

            LoadUserPreferences();

            //command line arguments will override other config source, so load it last
            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];
                if (arg.Contains("="))
                {
                    string[] parts = arg.Substring(2).Split('=', 2);
                    if (parts.Length == 2)
                    {
                        string name = parts[0];
                        string value = parts[1];
                        ce = new ConfigElement
                        {
                            Name = name,
                            Value = value,
                            Sourcename = "CommandLine",
                            Category = "General",
                            MustBeDefined = false
                        };
                        AddConfigElement(ce);
                    }
                }
            }

        }

        public void SaveUserPreferences()
        {
            // Implement logic to save user preferences to a file
            // This could involve serializing the ConfigElements list to JSON, XML, or another format
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(path, System.Reflection.Assembly.GetEntryAssembly().GetName().Name);
            
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            List<ConfigElement> userPreferences = ConfigElements.Where(e => e.IsUserPreference).ToList();

            string jsonString = JsonSerializer.Serialize(userPreferences);

            // 3. Save to a file
            File.WriteAllText(Path.Combine(folderPath, "userPreferences.json"), jsonString);

        }

        private void LoadUserPreferences()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string folderPath = Path.Combine(path, System.Reflection.Assembly.GetEntryAssembly().GetName().Name);
            string filePath = Path.Combine(folderPath, "userPreferences.json");

            try
            {
                if (File.Exists(filePath))
                {
                    string jsonString = File.ReadAllText(filePath);
                    List<ConfigElement> userPreferences = JsonSerializer.Deserialize<List<ConfigElement>>(jsonString);
                    userPreferences.ForEach(pref =>
                    {
                        AddConfigElement(pref);
                    });
                }
            }
            catch (Exception ex)
            {
                //don't want application crash for user preference loading failure, just log the error
                // Handle any exceptions that occur during loading user preferences
                Console.WriteLine($"Error loading user preferences: {ex.Message}");
            }
        }

        public void AssertPresence(List<string> requiredConfigNames)
        {
            var missingConfigs = requiredConfigNames.Where(name => !ConfigElements.Any(e => e.Name == name)).ToList();
            if (missingConfigs.Any())
            {
                throw new Exception($"Missing required configuration elements: {string.Join(", ", missingConfigs)}");
            }
        }

        public void AssertValidity()
        {
            var invalidConfigs = ConfigElements.Where(e => !e.IsValid).ToList();
            if (invalidConfigs.Any())
            {
                throw new Exception($"Invalid configuration elements: {string.Join(", ", invalidConfigs.Select(e => e.Name))}");
            }
        }

        public List<ConfigElement> ConfigElements { get; set; }


    }
}
