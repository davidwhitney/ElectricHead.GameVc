using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

namespace StarCrucible.GameVc.Results
{
    public class Exit : ActionResult
    {
        public override void Execute(Game game, SceneDispatcher dispatcher)
        {
            game.Exit();
        }
    }
}