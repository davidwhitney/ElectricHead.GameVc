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

        public IScene CurrentScene { get; set; }
        public GameTime CurrentTime { get; set; }

        public RenderingContext(Game game, GraphicsDeviceManager graphicsDevice)
        {
            Game = game;
            GraphicsDevice = graphicsDevice;
        }

        public RenderingContext WithSceneAtTime(IScene currentScene, GameTime now)
        {
            CurrentScene = currentScene;
            CurrentTime = now;
            return this;
        }
    }
}