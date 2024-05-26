using Verse;

namespace EvenBetterPriorities.Core
{
    public class EvenBetterPrioritiesGameComponent : GameComponent
    {
        public EvenBetterPrioritiesGameComponent(Game game)
        {
            Log.Message("EvenBetterPriorities: GameComponent created.");
        }

        public override void FinalizeInit()
        {
            base.FinalizeInit();
            Log.Message("EvenBetterPriorities: FinalizeInit called.");
            // Additional initialization can be done here
        }
    }
}
