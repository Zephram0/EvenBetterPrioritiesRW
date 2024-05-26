using System.Collections.Generic;
using RimWorld;
using Verse;
using HarmonyLib;
using UnityEngine;
using EvenBetterPriorities.Utilities;
using System;

namespace EvenBetterPriorities.Core
{
    [StaticConstructorOnStartup]
    public static class EvenBetterPriorities
    {
        static EvenBetterPriorities()
        {
            try
            {
                Log.Message("EvenBetterPriorities: Starting static initialization...");
                RegisterGameComponent();
                Log.Message("EvenBetterPriorities: Static initialization complete!");
            }
            catch (Exception ex)
            {
                Log.Error($"EvenBetterPriorities: Initialization failed - {ex.Message}\n{ex.StackTrace}");
            }
        }

        private static void RegisterGameComponent()
        {
            LongEventHandler.QueueLongEvent(() =>
            {
                try
                {
                    if (Current.Game != null)
                    {
                        var gameComponent = Current.Game.GetComponent<EvenBetterPrioritiesGameComponent>();
                        if (gameComponent == null)
                        {
                            Current.Game.components.Add(new EvenBetterPrioritiesGameComponent(Current.Game));
                            Log.Message("EvenBetterPriorities: GameComponent registered.");
                        }
                    }
                    else
                    {
                        Log.Error("EvenBetterPriorities: Current.Game is null during GameComponent registration.");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"EvenBetterPriorities: RegisterGameComponent failed - {ex.Message}\n{ex.StackTrace}");
                }
            }, "Initializing EvenBetterPriorities", false, null);
        }

        public static List<Pawn> disabledPawns = new List<Pawn>();
        public static List<WorkTypeDef> disabledWorkTypes = new List<WorkTypeDef>();
        public static int currentPawnIndex = 0;

        public static void DisablePawn(Pawn pawn)
        {
            if (!disabledPawns.Contains(pawn))
            {
                disabledPawns.Add(pawn);
                Log.Message($"{pawn.Name.ToStringShort} is now disabled for automatic updates.");
            }
        }

        public static void EnablePawn(Pawn pawn)
        {
            if (disabledPawns.Contains(pawn))
            {
                disabledPawns.Remove(pawn);
                Log.Message($"{pawn.Name.ToStringShort} is now enabled for automatic updates.");
            }
        }

        public static void DisableWorkType(WorkTypeDef workType)
        {
            if (!disabledWorkTypes.Contains(workType))
            {
                disabledWorkTypes.Add(workType);
                Log.Message($"{workType.defName} is now disabled for automatic updates.");
            }
        }

        public static void EnableWorkType(WorkTypeDef workType)
        {
            if (disabledWorkTypes.Contains(workType))
            {
                disabledWorkTypes.Remove(workType);
                Log.Message($"{workType.defName} is now enabled for automatic updates.");
            }
        }
    }
}
