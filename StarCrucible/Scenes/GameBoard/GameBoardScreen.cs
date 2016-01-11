using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.Results;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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
