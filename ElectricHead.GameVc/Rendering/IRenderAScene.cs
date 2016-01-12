using ElectricHead.GameVc.ControlFlow;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Rendering
{
    public interface IRenderAScene<in TSceneType> : IRenderAScene where TSceneType : IScene
    {
    }

    public interface IRenderAScene
    {
        void Draw(RenderingContext context, IScene currentScene, GameTime now);
    }
}
