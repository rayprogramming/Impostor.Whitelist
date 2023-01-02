using Impostor.Api.Events;
using Impostor.Api.Events.Client;
using Microsoft.Extensions.Logging;
using RayProgramming.Impostor.Whitelist;

namespace Rayprogramming.Impostor.Whitelist.Handlers;
public class ClientEventListener : IEventListener
{
    private readonly ILogger<ClientEventListener> _logger;
    private readonly WhitelistConfig _wlConfig;

    public ClientEventListener(ILogger<ClientEventListener> logger, WhitelistConfig wlConfig)
    {
        _logger = logger;
        _wlConfig = wlConfig;
    }

    [EventListener]
    public void OnClientConnected(IClientConnectedEvent e)
    {
        _logger.LogInformation("Client {name} > connected (language: {language}, chat mode: {chatMode})", e.Client.Name, e.Client.Language, e.Client.ChatMode);
        if (!_wlConfig.Usernames.Contains(e.Client.Name)) {
            _ = e.Connection.DisconnectAsync("Not in Whitelist");
        }
    }
}