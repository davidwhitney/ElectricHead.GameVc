using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes.Start
{
    public class StartScreenRenderer : IRenderAScene<StartScreen>
    {
        public void Draw(Game game, IScene current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
