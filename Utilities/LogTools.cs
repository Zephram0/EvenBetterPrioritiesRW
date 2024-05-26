using System;
using Verse;

namespace EvenBetterPriorities.Utilities
{
    public static class LogTools
    {
        public static void LogMessage(string message)
        {
            try
            {
                if (Core.Config.debugMode)
                {
                    string tickManagerState = Find.TickManager != null ? "initialized" : "null";
                    string currentMapState = Find.CurrentMap != null ? "initialized" : "null";
                    string worldState = Find.World != null ? "initialized" : "null";

                    Log.Message($"LogTools: Component states - TickManager: {tickManagerState}, CurrentMap: {currentMapState}, World: {worldState}");

                    if (Find.TickManager != null)
                    {
                        int ticksGame = Find.TickManager.TicksGame;
                        Log.Message($"[{ticksGame}] EvenBetterPriorities: {message}");
                    }
                    else
                    {
                        Log.Error("LogTools: Find.TickManager is null.");
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"LogTools.LogMessage failed: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
