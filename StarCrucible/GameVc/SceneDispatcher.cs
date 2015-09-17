using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc
{
    public class SceneDispatcher
    {
        private readonly Game _game;
        private readonly Stack<Type> _scenes;
        private readonly SceneCache _cache;
        private ISceneController Current => _cache.For(_scenes.Peek());

        public SceneDispatcher(Game game)
        {
            _game = game;
            _scenes = new Stack<Type>();
            _cache = new SceneCache();
        }

        public SceneDispatcher AddScene<T>()
        {
            _scenes.Push(typeof(T));
            return this;
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
                result.Execute(_game);
            }
        }

        public void Draw(GameTime time)
        {
        }
    }
}
