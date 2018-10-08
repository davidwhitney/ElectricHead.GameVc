using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ElectricHead.GameVc.Rendering;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Routing
{
    public class SceneRouteTable : ISceneRouteTable
    {
        public List<Type> Scenes { get; }
        public List<Type> Renderers { get; }
        public ISceneSelectionStrategy SceneSelectionStragety { get; set; }

        public SceneRouteTable()
        {
            SceneSelectionStragety = new DefaultSceneSelectionStrategy();
            Scenes = new List<Type>();
            Renderers = new List<Type>();
        }

        public Type DefaultScene()
        {
            var selected = SceneSelectionStragety.SelectStartScene(Scenes.Select(x => x.Name).ToArray());
            return Scenes.First(x => x.Name == selected);
        }

        public Type RendererFor<TSceneType>(TSceneType scene) where TSceneType : IScene
        {
            if (scene is IRenderAScene)
            {
                return scene.GetType();
            }

            foreach (var renderer in Renderers)
            {
                if (renderer.GetInterface(typeof(IRenderAScene<>).Name) != null
                    && renderer.GetInterface(typeof(IRenderAScene<>).Name).GetGenericArguments().Single() == scene.GetType())
                {
                    return renderer;
                }
            }

            throw new Exception("OMG NO RENDERER");
        }
    }
}