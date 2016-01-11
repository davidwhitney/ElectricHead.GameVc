using System;
using ElectricHead.GameVc.ControlFlow;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Results
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