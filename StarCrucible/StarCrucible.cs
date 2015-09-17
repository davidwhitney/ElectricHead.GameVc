using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StarCrucible.GameVc;
using StarCrucible.Scenes;

namespace StarCrucible
{
    public class StarCrucible : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private readonly SceneDispatcher _dispatcher;

        public StarCrucible()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _dispatcher = new SceneDispatcher(this)
                            .AddScene<StartController>();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _dispatcher.LoadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            _dispatcher.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _dispatcher.Draw(gameTime);
            base.Draw(gameTime);
        }
    }
}
