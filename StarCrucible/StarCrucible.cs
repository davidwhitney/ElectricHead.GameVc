using ElectricHead.GameVc.ControlFlow;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StarCrucible
{
    public class StarCrucible : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;
        private readonly SceneRouter _router;

        public StarCrucible()
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);
            _router = new SceneRouter(this);
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
