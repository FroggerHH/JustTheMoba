namespace JustTheMoba.Patch;

[HarmonyPatch(typeof(BaseAI)), HarmonyWrapSafe]
file static class IsTeamEnemy
{
    [HarmonyPatch(nameof(BaseAI.IsEnemy), [typeof(Character), typeof(Character)])]
    static bool Prefix(Character a, Character b, ref bool __result)
    {
        var f1 = a.GetFaction();
        var f2 = b.GetFaction();
        if (f1 == f2) return true;
        if (f1 != team_1 && f2 != team_2) return true;

        // We are guaranteed to deal with moba teams
        __result = f1 != f2 || (f1 != team_1 && f1 != team_2);
        return false;
    }
}