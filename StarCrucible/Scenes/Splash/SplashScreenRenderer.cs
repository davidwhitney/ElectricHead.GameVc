﻿using ElectricHead.GameVc;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace StarCrucible.Scenes.Splash
{
    public class SplashScreenRenderer : IRenderAScene<SplashScreen>
    {
        public void Draw(RenderingContext context)
        {
            context.Game.GraphicsDevice.Clear(Color.Black);
        }
    }
}