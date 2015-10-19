using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public void Register<TScene>()
            where TScene : IScene
        {
            Scenes.Add(typeof(TScene));

            var rendererName = typeof (TScene).Name.Replace(typeof(TScene).Name, typeof(TScene).Name + "Renderer");
            var rendererType = Assembly.GetAssembly(typeof (TScene)).GetTypes().FirstOrDefault(type => type.Name == rendererName);

            if (rendererType == null)
            {
                throw new Exception("Can't find renderer for " + typeof(TScene).FullName);
            }

            Renderers.Add((IRenderAScene)Activator.CreateInstance(rendererType));
        }
        
        public IRenderAScene RendererFor(IScene scene)
        {
            return Renderers.First(x => x.Supports(scene));
        }
    }
}