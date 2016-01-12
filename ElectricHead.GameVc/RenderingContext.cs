using ElectricHead.GameVc.ControlFlow;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElectricHead.GameVc
{
    public class RenderingContext
    {
        public Game Game { get; set; }
        public GraphicsDeviceManager GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
    }
}