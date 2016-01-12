using System;
using System.Collections.Generic;
using System.Linq;
using ElectricHead.GameVc.Rendering;

namespace ElectricHead.GameVc.Routing
{
    public class SceneRouteTable : ISceneRouteTable
    {
        public List<Type> Scenes { get; }
        public List<IRenderAScene> Renderers { get; }
        public ISceneSelectionStrategy SceneSelectionStragety { get; set; }

        public SceneRouteTable()
        {
            SceneSelectionStragety = new DefaultSceneSelectionStrategy();
            Scenes = new List<Type>();
            Renderers = new List<IRenderAScene>();
        }

        public Type DefaultScene()
        {
            var selected = SceneSelectionStragety.SelectStartScene(Scenes.Select(x => x.Name).ToArray());
            return Scenes.First(x => x.Name == selected);
        }

        public IRenderAScene RendererFor(IScene scene)
        {
            foreach (var renderer in Renderers)
            {
                if (renderer.GetType().Name.StartsWith(scene.GetType().Name)) // This is naff, but w/e
                {
                    return renderer;
                }
            }

            throw new Exception("OMG NO RENDERER");
            // maybe something like return Renderers.First(x => x.Supports(scene));
        }

    }
}