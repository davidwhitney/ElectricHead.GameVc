using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes.Splash
{
    public class SplashScreenRenderer : IRenderAScene<SplashScreen>
    {
        public void Draw(Game game, IScene current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
        }
    }
}