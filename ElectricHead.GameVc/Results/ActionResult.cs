using ElectricHead.GameVc.ControlFlow;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Results
{
    public abstract class ActionResult
    {
        public abstract void Execute(Game game, ISceneRouting router);
    }
}