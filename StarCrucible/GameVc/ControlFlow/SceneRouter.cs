using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace StarCrucible.GameVc.ControlFlow
{
    public class SceneRouter : ISceneRouting
    {
        private readonly Game _game;
        private readonly GameLoop _gameLoop;
        private readonly SceneRegistry _sceneRegistry;
        private readonly SceneCache _cache;

        private IScene Current => _cache.For(_sceneRegistry.Scenes.First());

        public SceneRouter(Game game)
        {
            _game = game;
            _cache = new SceneCache();

            _sceneRegistry = new SceneRegistry();
            _sceneRegistry.AutoRegister();
            RedirectTo(_sceneRegistry.SelectDefaultScene());

            _gameLoop = new GameLoop(_game, this,
                t => Current.PreUpdate(),
                t => Current.Update(t)
                );
        }

        public SceneRouter StartWith<TScene>()
            where TScene : IScene
        {
            RedirectTo(typeof(TScene));
            return this;
        }

        public void RedirectTo(Type scene)
        {
            var offset = _sceneRegistry.Scenes.IndexOf(scene);
            var sceneType = _sceneRegistry.Scenes[offset];
            _sceneRegistry.Scenes.RemoveAt(offset);
            _sceneRegistry.Scenes.Insert(0, sceneType);
        }

        public void LoadContent()
        {
            Current.LoadContent();
        }

        public void Update(GameTime time)
        {
            _gameLoop.Invoke(time);
        }

        public void Draw(GameTime time)
        {
            _sceneRegistry.RendererFor(Current).Draw(_game, Current, time);
        }
    }
}
