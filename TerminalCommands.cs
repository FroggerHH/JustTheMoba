namespace JustTheMoba;

[HarmonyWrapSafe]
[HarmonyPatch(typeof(Terminal), nameof(InitTerminal))]
file static class TerminalCommands
{
    [UsedImplicitly]
    private static void Postfix()
    {
        new ConsoleCommand("select_team", "$select_team".Localize(),
            (args) =>
            {
                if (args.Length < 2) throw new ConsoleCommandException("$JustTheMoba_err_no_team".Localize());
                var team = args[1];
                m_localPlayer.m_faction = team switch
                {
                    "team_1" => team_1,
                    "team_2" => team_2,
                    "reset" => Character.Faction.Players,
                    _ => throw new ConsoleCommandException(string.Format("$JustTheMoba_err_invalid_team".Localize(), team))
                };
            }, isCheat: false, alwaysRefreshTabOptions: true, optionsFetcher: () => ["team_1", "team_2", "reset"]);
    }
}