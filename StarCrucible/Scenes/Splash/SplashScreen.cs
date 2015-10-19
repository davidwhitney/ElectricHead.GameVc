using System;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Results;
using StarCrucible.Scenes.Start;
using static StarCrucible.GameVc.Results.And;

namespace StarCrucible.Scenes.Splash
{
    public class SplashScreen : Scene
    {
        public override ActionResult Update(GameTime gameTime)
        {
            return gameTime.TotalGameTime < TimeSpan.FromSeconds(5)
                ? NoOp
                : (ActionResult) ChangeSceneTo<StartScreen>();
        }
    }
}