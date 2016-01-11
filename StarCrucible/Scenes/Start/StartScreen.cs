﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Results;
using static StarCrucible.GameVc.Results.And;

namespace StarCrucible.Scenes.Start
{
    public class StartScreen : Scene
    {
        public override ActionResult PreUpdate()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return QuitToDesktop;
            }

            return NoOp;
        }
    }
}