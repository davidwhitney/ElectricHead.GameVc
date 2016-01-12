using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Routing.Results
{
    public class Exit : ActionResult
    {
        public override void Execute(Game game, ISceneRouter router)
        {
            game.Exit();
        }
    }
}