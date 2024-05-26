using RimWorld;
using System.Linq;
using Verse;

namespace EvenBetterPriorities.JobManagement
{
    public static class JobPriorityCalculator
    {
        private static SkillRecord GetRelevantSkill(Pawn pawn, WorkTypeDef workType)
        {
            var relevantSkill = workType.relevantSkills?.FirstOrDefault();
            return relevantSkill == null ? null : pawn.skills?.GetSkill(relevantSkill);
        }

        public static int CalculateWorkPriority(Pawn pawn, WorkTypeDef workType)
        {
            var skill = GetRelevantSkill(pawn, workType);

            // Explicitly handle the possible null return
            if (skill == null) return 0;

            return skill.Level + 5 * ((int)skill.passion + (int)skill.LearnRateFactor());
        }
    }
}
