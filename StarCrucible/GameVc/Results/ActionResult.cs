using Microsoft.Xna.Framework;

namespace StarCrucible.GameVc.Results
{
    public abstract class ActionResult
    {
        public abstract void Execute(Game game);
    }

    public class Exit : ActionResult
    {
        private Exit() { }

        public override void Execute(Game game)
        {
            game.Exit();
        }

        public static readonly Exit Game = new Exit();
    }

    public class Do : ActionResult
    {
        public override void Execute(Game game)
        {
            // NoOp
        }

        public static readonly Do Nothing = new Do();
    }
}