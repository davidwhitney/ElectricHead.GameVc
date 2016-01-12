using System;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Routing.Results
{
    public class ChangeScene : ActionResult
    {
        public Type TargetScene { get; set; }

        public ChangeScene(Type targetScene)
        {
            TargetScene = targetScene;
        }

        public override void Execute(Game game, ISceneRouter router)
        {
            router.RedirectTo(TargetScene);
        }
    }
}