using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc
{
    public class SceneController : ISceneController
    {
        public virtual void LoadContent()
        {
        }

        public virtual ActionResult PreUpdate()
        {
            return Do.Nothing;
        }

        public virtual ActionResult Update(GameTime gameTime)
        {
            return Do.Nothing;
        }

        public virtual ActionResult PostUpdate()
        {
            return Do.Nothing;
        }

        public void UnloadContent()
        {
        }
    }
}
