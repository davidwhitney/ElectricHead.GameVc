using System;
using Microsoft.Xna.Framework;
using StarCrucible.GameVc.ControlFlow;

namespace StarCrucible.GameVc.Results
{
    public class ChangeScene : ActionResult
    {
        public Type TargetScene { get; set; }

        public ChangeScene(Type targetScene)
        {
            TargetScene = targetScene;
        }

        public override void Execute(Game game, ISceneRouting router)
        {
            router.RedirectTo(TargetScene);
        }
    }
}