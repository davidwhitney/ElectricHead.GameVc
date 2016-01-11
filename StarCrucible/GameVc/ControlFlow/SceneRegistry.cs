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

        public void AutoRegisterFromNamespaceContaining<T>()
        {
            AutoRegister(typeof (T).Namespace);
        }

        public void AutoRegister(string @namespace = null)
        {
            var candidateTypes = new List<Type>();
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                candidateTypes.AddRange(assembly.GetTypes().ToList());
            }

            if (@namespace != null)
            {
                candidateTypes = candidateTypes.Where(x => x.Namespace != null && x.Namespace.StartsWith(@namespace)).ToList();
            }

            candidateTypes.RemoveAll(x => x == typeof (Scene));

            var scenes = candidateTypes
                .Where(type => type.GetInterfaces().Contains(typeof (IScene))
                               && type.IsClass
                               && !type.IsAbstract).ToList();
            
            foreach (var scene in scenes)
            {
                Register(scene);
            }
        }
        
        public SceneRegistry Register<TScene>()
            where TScene : IScene
        {
            return Register(typeof (TScene));
        }

        private SceneRegistry Register(Type sceneType)
        {
            Scenes.Add(sceneType);

            var rendererName = sceneType.Name.Replace(sceneType.Name, sceneType.Name + "Renderer");
            var rendererType = Assembly.GetAssembly(sceneType).GetTypes().FirstOrDefault(type => type.Name == rendererName);

            if (rendererType == null)
            {
                throw new Exception("Can't find renderer for " + sceneType.FullName);
            }

            Renderers.Add((IRenderAScene)Activator.CreateInstance(rendererType));
            return this;
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