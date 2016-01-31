using ElectricHead.GameVc;
using ElectricHead.GameVc.Routing.Results;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SampleGame.Scenes.Start
{
    public class StartScreen : Scene
    {
        public override ActionResult PreUpdate()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return And.QuitToDesktop;
            }

            return And.NoOp;
        }

        public override ActionResult Update(GameTime gameTime)
        {
            return And.NoOp;
        }

        public override ActionResult PostUpdate()
        {
            return And.NoOp;
        }
    }
}
