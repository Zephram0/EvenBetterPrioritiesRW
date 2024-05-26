using Verse;

namespace EvenBetterPriorities.JobManagement
{
    public static class JobHandler
    {
        public static void AdjustPriorities(Pawn pawn)
        {
            try
            {
                if (pawn == null || Core.EvenBetterPriorities.disabledPawns.Contains(pawn) || !JobAssigner.IsValidPawn(pawn))
                {
                    //Utilities.LogTools.LogMessage($"Skipping pawn {pawn?.Name.ToStringShort} as it's disabled or invalid.");
                    return;
                }

                Utilities.LogTools.LogMessage($"Adjusting priorities for pawn {pawn.Name.ToStringShort}.");
                JobAssigner.AssignWorkPriorities(pawn);
            }
            catch (System.Exception ex)
            {
                Log.Error($"Unexpected error adjusting priorities for pawn {pawn?.Name.ToStringShort}. Exception: {ex}");
            }
        }
    }
}
