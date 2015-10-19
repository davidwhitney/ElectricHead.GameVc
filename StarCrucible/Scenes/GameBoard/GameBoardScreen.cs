using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Results;

namespace StarCrucible.Scenes.GameBoard
{
    public class GameBoardScreen : Scene
    {
        public override ActionResult PreUpdate()
        {
            return And.NoOp;
        }
    }
}
