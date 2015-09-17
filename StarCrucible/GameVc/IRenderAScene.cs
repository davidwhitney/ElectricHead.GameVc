using Microsoft.Xna.Framework;

namespace StarCrucible.GameVc
{
    public interface IRenderAScene<TSceneType>
    {
        void Draw(GameTime gameTime);
    }
}
