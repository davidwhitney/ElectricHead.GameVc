using Microsoft.Xna.Framework;
using StarCrucible.GameVc;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Rendering;

namespace StarCrucible.Scenes.Splash
{
    public class SplashScreenRenderer : IRenderAScene
    {
        public bool Supports(IScene scene)
        {
            return scene.GetType() == typeof (SplashScreen);
        }

        public void Draw(Game game, IScene current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
        }
    }
}