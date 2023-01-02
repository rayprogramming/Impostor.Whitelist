using System.Threading.Tasks;
using Impostor.Api.Games.Managers;
using Impostor.Api.Innersloth;
using Impostor.Api.Innersloth.GameOptions;
using Impostor.Api.Plugins;
using Microsoft.Extensions.Logging;

namespace RayProgramming.Impostor.Whitelist;
[ImpostorPlugin("com.rayprogramming.impostor.whitelist")]
public class WhitelistPlugin : PluginBase
{
    private readonly ILogger<WhitelistPlugin> _logger;
    private readonly IGameManager _gameManager;

    public WhitelistPlugin(ILogger<WhitelistPlugin> logger, IGameManager gameManager)
    {
        _logger = logger;
        _gameManager = gameManager;
    }

    public override ValueTask EnableAsync()
    {
        _logger.LogInformation("Whitelist is being enabled.");
        return default;
    }

    public override ValueTask DisableAsync()
    {
        _logger.LogInformation("Whitelist is being disabled.");
        return default;
    }
}
