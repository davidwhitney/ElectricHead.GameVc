using Microsoft.Xna.Framework;
using StarCrucible.GameVc;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Rendering;

namespace StarCrucible.Scenes.Start
{
    public class StartScreenRenderer : IRenderAScene
    {
        public bool Supports(IScene scene)
        {
            return scene.GetType() == typeof (StartScreen);
        }

        public void Draw(Game game, IScene current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
