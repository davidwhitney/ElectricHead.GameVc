using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

namespace StarCrucible.GameVc.Results
{
    public abstract class ActionResult
    {
        public abstract void Execute(Game game, SceneDispatcher dispatcher);
    }
}