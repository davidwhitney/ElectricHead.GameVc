using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

namespace StarCrucible.GameVc.Rendering
{
    public interface IRenderAScene
    {
        bool Supports(ISceneController scene);
        void Draw(Game game, ISceneController current, GameTime gameTime);
    }
}
