using HarmonyLib;
using RimWorld;
using Verse;

namespace EvenBetterPriorities.Patches
{
    [HarmonyPatch(typeof(Game), "InitNewGame")]
    public static class Game_InitNewGame_Patch
    {
        public static void Postfix()
        {
            Utilities.LogTools.LogMessage("Game initialized, capturing all jobs on demand.");
        }
    }

    [HarmonyPatch(typeof(Game), "LoadGame")]
    public static class Game_LoadGame_Patch
    {
        public static void Postfix()
        {
            Utilities.LogTools.LogMessage("Game loaded, capturing all jobs on demand.");
        }
    }
}
