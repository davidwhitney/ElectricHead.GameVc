using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc
{
    public class SceneDispatcher
    {
        private readonly Game _game;
        private readonly List<Type> _scenes;
        private readonly List<IRenderAScene> _renderers;
        private readonly SceneCache _cache;
        private ISceneController Current => _cache.For(_scenes.First());

        public SceneDispatcher(Game game)
        {
            _game = game;
            _scenes = new List<Type>();
            _renderers = new List<IRenderAScene>();
            _cache = new SceneCache();
        }

        public SceneDispatcher AddSceneWithRenderer<TScene, TRenderer>() 
            where TScene : ISceneController
            where TRenderer : IRenderAScene
        {
            AddScene<TScene>();
            AddRenderer((IRenderAScene)Activator.CreateInstance<TRenderer>());
            return this;
        }

        public SceneDispatcher AddScene<T>()
        {
            _scenes.Add(typeof(T));
            return this;
        }

        public SceneDispatcher AddRenderer(IRenderAScene renderer)
        {
            _renderers.Add(renderer);
            return this;
        }

        public void RedirectTo(Type scene)
        {
            var offset = _scenes.IndexOf(scene);
            var sceneType = _scenes[offset];
            _scenes.RemoveAt(offset);
            _scenes.Insert(0, sceneType);
        }

        public void LoadContent()
        {
            Current.LoadContent();
        }

        public void Update(GameTime time)
        {
            var steps = new List<Func<ActionResult>>
            {
                () => Current.PreUpdate(),
                () => Current.Update(time)
            };

            foreach (var step in steps)
            {
                var result = step();
                result.Execute(_game, this);
            }
        }

        public void Draw(GameTime time)
        {
            foreach (var renderer in _renderers)
            {
                if (renderer.Supports(Current))
                {
                    renderer.Draw(_game, Current, time);
                }
            }
        }

    }
}
