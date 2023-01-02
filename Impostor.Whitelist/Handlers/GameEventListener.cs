using Impostor.Api.Events;
using Impostor.Api.Games;
using Impostor.Api.Innersloth;
using Microsoft.Extensions.Logging;
using RayProgramming.Impostor.Whitelist;

namespace Rayprogramming.Impostor.Whitelist.Handlers;
public class GameEventListener : IEventListener
{
    private readonly ILogger<GameEventListener> _logger;
    private readonly WhitelistConfig _wlConfig;

    public GameEventListener(ILogger<GameEventListener> logger, WhitelistConfig wlConfig)
    {
        _logger = logger;
        _wlConfig = wlConfig;
    }

    [EventListener]
    public void OnGameCreated(IGameCreationEvent e)
    {
        _logger.LogInformation("Game creation requested by {client}", e.Client == null ? "a plugin" : e.Client.Name);
        if (e.Client == null || !_wlConfig.Usernames.Contains(e.Client.Name)) {
            _logger.LogInformation("Game creation canceled because {client} is not in whitelist {whitelist}", e.Client == null ? "a plugin" : e.Client.Name, _wlConfig.Usernames);
            e.IsCancelled = true;
        }
    }
}