using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.Results;

namespace StarCrucible.GameVc.ControlFlow
{
    public class GameLoop : List<Func<GameTime, ActionResult>>
    {
        private readonly Game _game;
        private readonly SceneRouter _sceneRouter;

        public GameLoop(Game game, SceneRouter sceneRouter, params Func<GameTime, ActionResult>[] ops)
        {
            _game = game;
            _sceneRouter = sceneRouter;
            AddRange(ops);
        }

        public void Invoke(GameTime time)
        {
            foreach (var step in this)
            {
                var result = step(time);
                result?.Execute(_game, _sceneRouter);
            }
        }
    }
}