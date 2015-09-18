using Microsoft.Xna.Framework;

namespace StarCrucible.GameVc
{
    public interface IRenderAScene
    {
        bool Supports(ISceneController scene);
        void Draw(Game game, ISceneController current, GameTime gameTime);
    }
}
