using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarCrucible.GameVc;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.Scenes;
using StarCrucible.Scenes.Splash;
using StarCrucible.Scenes.Start;

namespace StarCrucible
{
    public class StarCrucible : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private readonly SceneRouter _router;

        public StarCrucible()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _router = new SceneRouter(this)
                .AddSceneWithRenderer<SplashScreen, SplashScreenRenderer>()
                .AddSceneWithRenderer<StartScreen, StartScreenRenderer>();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _router.LoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _router.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _router.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
