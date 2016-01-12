using System;
using ElectricHead.GameVc;
using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.Routing.Results;
using Microsoft.Xna.Framework;
using StarCrucible.Scenes.Start;
using static ElectricHead.GameVc.Routing.Results.And;

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