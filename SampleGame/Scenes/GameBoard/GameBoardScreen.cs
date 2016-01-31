using ElectricHead.GameVc;
using ElectricHead.GameVc.Routing.Results;

namespace SampleGame.Scenes.GameBoard
{
    public class GameBoardScreen : Scene
    {
        public override ActionResult PreUpdate()
        {
            return And.NoOp;
        }
    }
}
