using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Routing.Results
{
    public abstract class ActionResult
    {
        public abstract void Execute(Game game, ISceneRouter router);
    }
}