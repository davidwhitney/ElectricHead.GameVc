using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Rendering;

namespace StarCrucible.Scenes.GameBoard
{
    public class GameBoardScreenRenderer : IRenderAScene
    {
        public bool Supports(IScene scene)
        {
            return scene.GetType() == typeof (GameBoardScreen);
        }

        public void Draw(Game game, IScene current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
