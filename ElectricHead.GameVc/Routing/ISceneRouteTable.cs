using System;
using System.Collections.Generic;
using ElectricHead.GameVc.Rendering;

namespace ElectricHead.GameVc.Routing
{
    public interface ISceneRouteTable
    {
        List<Type> Scenes { get; }
        List<Type> Renderers { get; }
        ISceneSelectionStrategy SceneSelectionStragety { get; set; }
        Type DefaultScene();
        Type RendererFor<TSceneType>(TSceneType scene) where TSceneType : IScene;
    }
}