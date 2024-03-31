using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using LocalizationManager;

namespace JustTheMoba;

[BepInPlugin(ModGUID, ModName, ModVersion)]
[BepInDependency("com.Frogger.NoUselessWarnings", DependencyFlags.SoftDependency)]
internal class Plugin : BaseUnityPlugin
{
    private const string ModName = "JustTheMoba",
        ModVersion = "0.1.0",
        ModGUID = $"com.{ModAuthor}.{ModName}",
        ModAuthor = "Frogger";
    
    public static Character.Faction team_1 = (Character.Faction)71;
    public static Character.Faction team_2 = (Character.Faction)72;

    internal static ConfigEntry<int> maxFuelConfig;

    private void Awake()
    {
        CreateMod(this, ModName, ModAuthor, ModVersion, ModGUID, true);
        OnConfigurationChanged += UpdateConfiguration;

        maxFuelConfig = config("Fuelling", "Max fuel", 100, "");

        Localizer.Load();
    }

    private static void UpdateConfiguration()
    {
        // m_maxFuel = maxFuelConfig.Value;
    }
}