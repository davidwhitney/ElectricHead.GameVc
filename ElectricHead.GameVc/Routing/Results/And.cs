using System;

namespace ElectricHead.GameVc.Routing.Results
{
    public static class And
    {
        public static readonly Continue NoOp = new Continue();
        public static readonly Exit QuitToDesktop = new Exit();
        public static ChangeScene ChangeSceneTo<TTargetType>() { return new ChangeScene(typeof(TTargetType)); }
        public static ChangeScene ChangeSceneTo(Type sceneType) { return new ChangeScene(sceneType); }
    }
}