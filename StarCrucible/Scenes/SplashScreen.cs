using System;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc;
using StarCrucible.GameVc.Results;

namespace StarCrucible.Scenes
{
    public class SplashScreen : SceneController
    {
        private GameTime _firstCalled;

        public override ActionResult Update(GameTime gameTime)
        {
            if (_firstCalled == null)
            {
                _firstCalled = gameTime;
                return Do.Nothing;
            }

            if (gameTime.TotalGameTime >= TimeSpan.FromSeconds(5))
            {
                return Scene.Change<StartScreen>();
            }

            return Do.Nothing;
        }
    }
}