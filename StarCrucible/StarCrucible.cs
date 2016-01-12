using System;
using ElectricHead.GameVc;
using Microsoft.Xna.Framework;

namespace StarCrucible
{
    public class StarCrucible : Game
    {
        private readonly GameVc _gameVc;

        public StarCrucible()
        {
            _gameVc = new GameVc(this)
                            .AutoregisterScenes()
                            .OnError(HandleErrors)
                            .StartGame();
        }

        protected override void LoadContent()
        {
            _gameVc.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            _gameVc.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _gameVc.Draw(gameTime);
            base.Draw(gameTime);
        }

        private static void HandleErrors(Exception obj)
        {
            Console.WriteLine(obj.ToString());
        }
    }
}
