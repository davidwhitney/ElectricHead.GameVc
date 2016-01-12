using System;

namespace ElectricHead.GameVc.Routing
{
    public interface ISceneRouter
    {
        IScene Current { get; }
        SceneRouter StartWith<TScene>() where TScene : IScene;
        void RedirectTo(Type scene);
    }
}