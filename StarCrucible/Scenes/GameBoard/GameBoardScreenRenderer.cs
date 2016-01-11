using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes.GameBoard
{
    public class GameBoardScreenRenderer : IRenderAScene<GameBoardScreen>
    {
        public void Draw(Game game, IScene current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
