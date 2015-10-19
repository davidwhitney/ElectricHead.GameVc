using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc.ControlFlow
{
    public interface IScene
    {
        void LoadContent();
        ActionResult PreUpdate();
        ActionResult Update(GameTime gameTime);
        ActionResult PostUpdate();
        void UnloadContent();
    }
}
