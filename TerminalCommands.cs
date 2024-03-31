namespace JustTheMoba;

[HarmonyWrapSafe]
[HarmonyPatch(typeof(Terminal), nameof(InitTerminal))]
file static class TerminalCommands
{
    [UsedImplicitly]
    private static void Postfix()
    {
        new ConsoleCommand("select_team",
            "Select your team. Available teams: 'team_1', 'team_2'. Use 'reset' to exit team and become normal player",
            (args) =>
            {
                if (args.Length < 2)
                    throw new ConsoleCommandException(
                        "Target team must be specified. Use 'team_1' or 'team_2' or 'reset'");
                var team = args[1];
                m_localPlayer.m_faction = team switch
                {
                    "team_1" => team_1,
                    "team_2" => team_2,
                    "reset" => Character.Faction.Players,
                    _ => throw new ConsoleCommandException(
                        "Supported teams: 'team_1', 'team_2', 'reset'. Use 'reset' if you want to reset your team.")
                };
            }, isCheat: false, alwaysRefreshTabOptions: true,
            optionsFetcher: () => ["team_1", "team_2", "reset"]);
    }
}