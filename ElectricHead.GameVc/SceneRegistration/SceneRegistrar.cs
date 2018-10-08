using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ElectricHead.GameVc.Rendering;
using ElectricHead.GameVc.Routing;

namespace ElectricHead.GameVc.SceneRegistration
{
    public class SceneRegistrar : IRegisterScenes
    {
        private readonly ISceneRouteTable _routeTable;

        public SceneRegistrar(ISceneRouteTable routeTable)
        {
            _routeTable = routeTable;
        }

        public void RegisterScenesFromNamespaceContaining<T>()
        {
            DiscoverAndRegisterScenes(typeof(T).Namespace);
        }

        public void DiscoverAndRegisterScenes(string @namespace = null)
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

            candidateTypes.RemoveAll(x => x == typeof(Scene));

            var scenes = candidateTypes
                .Where(type => type.GetInterfaces().Contains(typeof(IScene))
                               && type.IsClass
                               && !type.IsAbstract).ToList();

            foreach (var scene in scenes)
            {
                Register(scene);
            }
        }

        public IRegisterScenes Register<TScene>()
            where TScene : IScene
        {
            return Register(typeof(TScene));
        }

        private SceneRegistrar Register(Type sceneType)
        {
            _routeTable.Scenes.Add(sceneType);
            
            if (typeof(IRenderAScene).IsAssignableFrom(sceneType))
            {
                return this;
            }

            var rendererName = sceneType.Name.Replace(sceneType.Name, sceneType.Name + "Renderer");
            var rendererType = Assembly.GetAssembly(sceneType).GetTypes().FirstOrDefault(type => type.Name == rendererName);

            if (rendererType == null)
            {
                throw new Exception("Can't find renderer for " + sceneType.FullName);
            }

            _routeTable.Renderers.Add(rendererType);
            return this;
        }
    }
}