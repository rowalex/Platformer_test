using Platformer.Core;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

namespace Platformer.Gameplay
{
   
    /// <typeparam name="HealthIsZero"></typeparam>
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}