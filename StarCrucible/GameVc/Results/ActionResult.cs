using System;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

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

    public class ChangeScene : ActionResult
    {
        public Type TargetScene { get; set; }

        private ChangeScene(Type targetScene)
        {
            TargetScene = targetScene;
        }

        public override void Execute(Game game, SceneDispatcher dispatcher)
        {
            dispatcher.RedirectTo(TargetScene);
        }

        public static ChangeScene To<TTargetType>()
        {
            return new ChangeScene(typeof (TTargetType));
        }
    }
}