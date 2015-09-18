using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc.ControlFlow
{
    public interface ISceneController
    {
        void LoadContent();
        ActionResult PreUpdate();
        ActionResult Update(GameTime gameTime);
        ActionResult PostUpdate();
        void UnloadContent();
    }
}
