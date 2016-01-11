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
        private readonly ISceneSelectionStrategy _sceneSelectionStragety;

        private IScene Current => _cache.For(_sceneRegistry.Scenes.First());

        public SceneRouter(Game game)
        {
            _game = game;
            _cache = new SceneCache();
            _sceneRegistry = new SceneRegistry();
            _sceneSelectionStragety = new DefaultSceneSelectionStrategy();

            _sceneRegistry.AutoRegister();
            RedirectTo(DefaultScene());

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

        private Type DefaultScene()
        {
            var selected = _sceneSelectionStragety.SelectStartScene(_sceneRegistry.Scenes.Select(x => x.Name).ToArray());
            return _sceneRegistry.Scenes.First(x => x.Name == selected);
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
            var renderer = (IRenderAScene<IScene>) _sceneRegistry.RendererFor(Current);
            renderer.Draw(_game, Current, time);
        }
    }
}
