using Platformer.Core;
using Platformer.Mechanics;

namespace Platformer.Gameplay
{
    
    /// <typeparam name="PlayerLanded"></typeparam>
    public class PlayerLanded : Simulation.Event<PlayerLanded>
    {
        public PlayerController player;

        public override void Execute()
        {

        }
    }
}