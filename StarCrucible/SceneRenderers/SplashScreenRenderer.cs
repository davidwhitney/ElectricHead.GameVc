using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarCrucible.GameVc;
using StarCrucible.Scenes;

namespace StarCrucible.SceneRenderers
{
    public class SplashScreenRenderer : IRenderAScene
    {
        public bool Supports(ISceneController scene)
        {
            return scene.GetType() == typeof (SplashScreen);
        }

        public void Draw(Game game, ISceneController current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.Black);
        }
    }
}