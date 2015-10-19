using System;
using System.Collections.Generic;
using StarCrucible.GameVc.Rendering;

namespace StarCrucible.GameVc.ControlFlow
{
    public class SceneRegistry
    {
        public readonly List<Type> Scenes;
        public readonly List<IRenderAScene> Renderers;
        
        public SceneRegistry()
        {
            Scenes = new List<Type>();
            Renderers = new List<IRenderAScene>();
        }
    }
}