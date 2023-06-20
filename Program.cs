using Microsoft.Extensions.DependencyInjection;
using Module3HW2.Services;
using Module3HW2.Services.Abstractions;

var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfigService, ConfigService>()
                .AddTransient<IContactService, ContactService>()
                .AddTransient<Module3HW2.Starter>()
                .BuildServiceProvider();
var start = serviceProvider.GetService<Module3HW2.Starter>();
start.Run();