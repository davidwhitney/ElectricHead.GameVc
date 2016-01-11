using ElectricHead.GameVc.Results;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.ControlFlow
{
    public class Scene : IScene
    {
        public virtual void LoadContent()
        {
        }

        public virtual ActionResult PreUpdate()
        {
            return And.NoOp;
        }

        public virtual ActionResult Update(GameTime gameTime)
        {
            return And.NoOp;
        }

        public virtual ActionResult PostUpdate()
        {
            return And.NoOp;
        }

        public void UnloadContent()
        {
        }
    }
}
