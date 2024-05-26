using RimWorld;
using Verse;

namespace EvenBetterPriorities.JobManagement
{
    public static class JobAssigner  // Ensure this class is public
    {
        public static void AssignWorkPriorities(Pawn pawn)
        {
            if (!IsValidPawn(pawn))
                return;

            foreach (var workType in DefDatabase<WorkTypeDef>.AllDefs)
            {
                if (pawn.WorkTypeIsDisabled(workType))
                    continue;

                int priority = JobPriorityCalculator.CalculateWorkPriority(pawn, workType);
                pawn.workSettings.SetPriority(workType, priority);
                Utilities.LogTools.LogMessage($"Set priority {priority} for pawn {pawn.Name.ToStringShort} on work type {workType.defName}.");
            }
        }

        public static bool IsValidPawn(Pawn pawn) // Make this method public
        {
            return pawn.IsColonist && !pawn.Dead && !pawn.Downed && !pawn.InMentalState;
        }
    }
}
