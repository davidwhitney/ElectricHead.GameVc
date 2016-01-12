using ElectricHead.GameVc;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes.GameBoard
{
    public class GameBoardScreenRenderer : IRenderAScene<GameBoardScreen>
    {
        public void Draw(RenderingContext context)
        {
            context.Game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
