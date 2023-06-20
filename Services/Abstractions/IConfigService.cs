using Module3HW2.Models;

namespace Module3HW2.Services.Abstractions
{
    public interface IConfigService
    {
        public Config ReadConfig();
        public void WriteConfig(Config config);
    }
}
