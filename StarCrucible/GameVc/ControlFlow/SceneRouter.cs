using System;
using System.Linq;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Rendering;

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

            _gameLoop = new GameLoop(_game, this,
                t => Current.PreUpdate(),
                t => Current.Update(t)
                );
        }

        public SceneRouter AddSceneWithRenderer<TScene, TRenderer>()
            where TScene : IScene
            where TRenderer : IRenderAScene
        {
            _sceneRegistry.Scenes.Add(typeof (TScene));
            _sceneRegistry.Renderers.Add(Activator.CreateInstance<TRenderer>());
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
            _sceneRegistry.Renderers.First(x => x.Supports(Current))
                      .Draw(_game, Current, time);
        }
    }
}
