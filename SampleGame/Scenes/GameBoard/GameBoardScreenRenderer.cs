using ElectricHead.GameVc;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace SampleGame.Scenes.GameBoard
{
    public class GameBoardScreenRenderer : IRenderAScene<GameBoardScreen>
    {
        public void Draw(RenderingContext context, GameBoardScreen currentScene, GameTime now)
        {
            context.Game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
