namespace RayProgramming.Impostor.Whitelist;

public class WhitelistConfig
{
    /**
     * <summary>
     * Gets the name of this config section.
     * </summary>
     */
    public const string Section = "Whitelist";

    public List<string> Usernames { get; set; } = new List<string>();
}