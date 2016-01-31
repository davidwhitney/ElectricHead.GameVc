using System;
using ElectricHead.GameVc;
using ElectricHead.GameVc.Routing.Results;
using Microsoft.Xna.Framework;
using SampleGame.Scenes.Start;

namespace SampleGame.Scenes.Splash
{
    public class SplashScreen : Scene
    {
        public override ActionResult Update(GameTime gameTime)
        {
            return gameTime.TotalGameTime < TimeSpan.FromSeconds(5)
                ? And.NoOp
                : (ActionResult) And.ChangeSceneTo<StartScreen>();
        }
    }
}