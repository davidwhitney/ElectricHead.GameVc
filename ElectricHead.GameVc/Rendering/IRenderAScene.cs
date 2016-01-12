using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Rendering
{
    public interface IRenderAScene<in TScene> where TScene : IScene
    {
        void Draw(RenderingContext context, TScene currentScene, GameTime now);
    }
}
