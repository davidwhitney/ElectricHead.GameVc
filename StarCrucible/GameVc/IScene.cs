using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes
{
    public interface IScene
    {
        void LoadContent();
        UpdateResult Update(GameTime gameTime);
        void UnloadContent();
    }
}
