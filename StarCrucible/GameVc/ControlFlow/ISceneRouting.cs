using System;

namespace StarCrucible.GameVc.ControlFlow
{
    public interface ISceneRouting
    {
        void RedirectTo(Type scene);
    }
}