using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc.ControlFlow
{
    public class SceneController : ISceneController
    {
        public virtual void LoadContent()
        {
        }

        public virtual ActionResult PreUpdate()
        {
            return And.Continue;
        }

        public virtual ActionResult Update(GameTime gameTime)
        {
            return And.Continue;
        }

        public virtual ActionResult PostUpdate()
        {
            return And.Continue;
        }

        public void UnloadContent()
        {
        }
    }
}
