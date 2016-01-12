using System;
using System.Collections.Generic;
using ElectricHead.GameVc.Rendering;

namespace ElectricHead.GameVc.Routing
{
    public interface ISceneRouteTable
    {
        List<Type> Scenes { get; }
        List<IRenderAScene> Renderers { get; }
        ISceneSelectionStrategy SceneSelectionStragety { get; set; }
        Type DefaultScene();
        IRenderAScene RendererFor(IScene scene);
    }
}