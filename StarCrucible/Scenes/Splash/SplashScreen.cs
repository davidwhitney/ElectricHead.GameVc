using System;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Results;
using StarCrucible.Scenes.Start;

namespace StarCrucible.Scenes.Splash
{
    public class SplashScreen : SceneController
    {
        public override ActionResult Update(GameTime gameTime)
        {
            return gameTime.TotalGameTime >= TimeSpan.FromSeconds(5)
                ? (ActionResult) ChangeScene.To<StartScreen>()
                : Do.Nothing;
        }
    }
}