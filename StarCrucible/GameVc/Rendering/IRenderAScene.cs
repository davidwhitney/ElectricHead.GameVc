using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

namespace StarCrucible.GameVc.Rendering
{
    public interface IRenderAScene<in TSceneType> : IRenderAScene where TSceneType : IScene
    {
        void Draw(Game game, IScene current, GameTime gameTime);
    }

    public interface IRenderAScene
    {
        
    }
}
