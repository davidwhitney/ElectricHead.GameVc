using System;
using ElectricHead.GameVc.Rendering;
using ElectricHead.GameVc.Routing.Results;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ElectricHead.GameVc.SceneTemplates
{
    public abstract class FullScreenImageScene : Scene, IRenderAScene
    {
        public string ImagePath { get; }
        public Type NextScene { get; }

        private Texture2D _image;

        protected FullScreenImageScene(string imagePath, Type nextScene)
        {
            ImagePath = imagePath;
            NextScene = nextScene;
        }

        public override void LoadContent(RenderingContext renderingContext)
        {
            _image = renderingContext.Load(ImagePath);
        }

        public override ActionResult Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return And.ChangeSceneTo(NextScene);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                return And.QuitToDesktop;
            }

            return And.NoOp;
        }

        public virtual void Draw(RenderingContext context, GameTime now)
        {
            context.GraphicsDevice.GraphicsDevice.Clear(Color.Orange);
            context.SpriteBatch.Begin();
            context.SpriteBatch.Draw(_image, new Rectangle(0, 0, _image.Width, _image.Height), Color.White);
            context.SpriteBatch.End();
        }
    }
}
