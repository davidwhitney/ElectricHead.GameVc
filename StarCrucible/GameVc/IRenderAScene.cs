using Microsoft.Xna.Framework;

namespace StarCrucible.SceneRenderers
{
    public interface IRenderAScene<TSceneType>
    {
        void Draw(GameTime gameTime);
    }
}
