using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StarCrucible.GameVc;
using StarCrucible.GameVc.Results;

namespace StarCrucible.Scenes
{
    public class StartController : SceneController
    {
        public override ActionResult PreUpdate()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return Exit.Game;
            }

            return Do.Nothing;
        }
    }
}
