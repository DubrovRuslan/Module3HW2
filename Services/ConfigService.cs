using Newtonsoft.Json;
using Module3HW2.Models;
using Module3HW2.Services.Abstractions;

namespace Module3HW2.Services
{
    internal class ConfigService : IConfigService
    {
        private const string ConfigPath = "config.json";
        public Config ReadConfig()
        {
            try
            {
                var configFile = File.ReadAllText(ConfigPath, System.Text.Encoding.UTF8);
                return JsonConvert.DeserializeObject<Config>(configFile);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void WriteConfig(Config config)
        {
            var configFile = JsonConvert.SerializeObject(config);
            File.WriteAllText(ConfigPath, configFile);
        }
    }
}
