using HarmonyLib;
using Verse;
using System.Linq;
using RimWorld;

namespace EvenBetterPriorities.Patches
{
    [HarmonyPatch(typeof(TickManager), "DoSingleTick")]
    public static class TickManager_DoSingleTick_Patch
    {
        private static bool processPawns = false;

        public static void Postfix()
        {
            try
            {
                Core.Config.tickCounter++;

                // Check if we should start processing pawns
                if (!processPawns && Core.Config.tickCounter % Core.Config.updateIntervalTicks == 0)
                {
                    processPawns = true;
                    Core.EvenBetterPriorities.currentPawnIndex = 0; // Ensure starting from the first pawn
                }

                // If in processing mode, update priorities for one pawn per tick
                if (processPawns)
                {
                    var pawns = PawnsFinder.AllMaps_FreeColonists.ToList();

                    if (Core.EvenBetterPriorities.currentPawnIndex < pawns.Count)
                    {
                        var pawn = pawns[Core.EvenBetterPriorities.currentPawnIndex];
                        JobManagement.JobHandler.AdjustPriorities(pawn);
                        Core.EvenBetterPriorities.currentPawnIndex++;
                        Utilities.LogTools.LogMessage("Single pawn priority update performed.");
                    }
                    else
                    {
                        // All pawns have been processed, stop processing and wait for the next interval
                        processPawns = false;
                        Core.Config.tickCounter = 0; // Reset the tick counter
                    }
                }
            }
            catch (System.Exception ex)
            {
                Log.Error($"Unexpected error in DoSingleTick postfix. Exception: {ex}");
            }
        }
    }
}