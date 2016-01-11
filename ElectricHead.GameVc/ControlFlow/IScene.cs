using ElectricHead.GameVc.Results;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.ControlFlow
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
