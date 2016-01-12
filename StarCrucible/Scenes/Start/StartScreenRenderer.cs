using ElectricHead.GameVc;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes.Start
{
    public class StartScreenRenderer : IRenderAScene<StartScreen>
    {
        public void Draw(RenderingContext context, StartScreen currentScene, GameTime now)
        {
            context.Game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
