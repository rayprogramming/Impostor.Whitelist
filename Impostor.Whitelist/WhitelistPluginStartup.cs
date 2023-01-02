using Impostor.Api.Events;
using Impostor.Api.Plugins;
using Rayprogramming.Impostor.Whitelist.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using RayProgramming.Impostor.Whitelist;
using Serilog;
using Impostor.Server.Utils;

namespace Impostor.Whitelist;
public class WhitelistPluginStartup : IPluginStartup
{
    public void ConfigureHost(IHostBuilder host)
    {
        WhitelistConfig config = CreateConfiguration().GetSection(WhitelistConfig.Section).Get<WhitelistConfig>() ?? new WhitelistConfig();
        host.ConfigureServices((host, services) =>
        {
            services.AddSingleton<WhitelistConfig>(config);
        });
    }
    
    private static IConfiguration CreateConfiguration()
    {
        var configurationBuilder = new ConfigurationBuilder();

        configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
        configurationBuilder.AddJsonFile("config_whitelist.json", true);
        configurationBuilder.AddJsonFile("config_whitelist.Development.json", true);
        configurationBuilder.AddEnvironmentVariables(prefix: "IMPOSTOR_WL_");

        return configurationBuilder.Build();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // services.AddSingleton<IEventListener, GameEventListener>();
        services.AddSingleton<IEventListener, ClientEventListener>();
        // services.AddSingleton<IEventListener, PlayerEventListener>();
        // services.AddSingleton<IEventListener, MeetingEventListener>();
    }
}