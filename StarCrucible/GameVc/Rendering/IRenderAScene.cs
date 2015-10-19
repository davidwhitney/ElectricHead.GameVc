using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

namespace StarCrucible.GameVc.Rendering
{
    public interface IRenderAScene
    {
        bool Supports(IScene scene);
        void Draw(Game game, IScene current, GameTime gameTime);
    }
}
