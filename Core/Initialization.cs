using HarmonyLib;
using Verse;
using EvenBetterPriorities.Utilities;
using System;

namespace EvenBetterPriorities.Core
{
    public static class Initialization
    {
        public static void Init()
        {
            try
            {
                LogTools.LogMessage("Initialization: Starting Harmony patching...");
                var harmony = new Harmony("com.yourname.evenbetterpriorities");
                harmony.PatchAll();
                LogTools.LogMessage("Initialization: Harmony patching completed.");
            }
            catch (Exception ex)
            {
                Log.Error($"Initialization: Harmony patching failed - {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
