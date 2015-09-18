using System;
using Microsoft.Xna.Framework;

namespace StarCrucible.GameVc.Results
{
    public abstract class ActionResult
    {
        public abstract void Execute(Game game, SceneDispatcher dispatcher);
    }

    public class Exit : ActionResult
    {
        private Exit() { }

        public override void Execute(Game game, SceneDispatcher dispatcher)
        {
            game.Exit();
        }

        public static readonly Exit Game = new Exit();
    }

    public class Do : ActionResult
    {
        public override void Execute(Game game, SceneDispatcher dispatcher)
        {
            // NoOp
        }

        public static readonly Do Nothing = new Do();
    }

    public class Scene : ActionResult
    {
        public Type TargetScene { get; set; }

        public override void Execute(Game game, SceneDispatcher dispatcher)
        {
            dispatcher.RedirectTo(TargetScene);
        }

        public static Scene Change<TTargetType>()
        {
            return new Scene {TargetScene = typeof (TTargetType)};
        }
    }
}