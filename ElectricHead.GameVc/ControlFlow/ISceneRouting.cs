using System;

namespace ElectricHead.GameVc.ControlFlow
{
    public interface ISceneRouting
    {
        void RedirectTo(Type scene);
    }
}