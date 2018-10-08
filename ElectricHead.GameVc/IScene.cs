using ElectricHead.GameVc.Routing.Results;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc
{
    public interface IScene
    {
        void LoadContent(RenderingContext renderingContext);
        ActionResult PreUpdate();
        ActionResult Update(GameTime gameTime);
        ActionResult PostUpdate();
        void UnloadContent();
    }
}
