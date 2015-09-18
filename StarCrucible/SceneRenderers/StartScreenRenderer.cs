using Microsoft.Xna.Framework;
using StarCrucible.GameVc;
using StarCrucible.Scenes;

namespace StarCrucible.SceneRenderers
{
    public class StartScreenRenderer : IRenderAScene
    {
        public bool Supports(ISceneController scene)
        {
            return scene.GetType() == typeof (StartScreen);
        }

        public void Draw(Game game, ISceneController current, GameTime gameTime)
        {
            game.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}
