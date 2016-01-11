using ElectricHead.GameVc.ControlFlow;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Results
{
    public class Exit : ActionResult
    {
        public override void Execute(Game game, ISceneRouting router)
        {
            game.Exit();
        }
    }
}