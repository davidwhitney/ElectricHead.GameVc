using System;
using System.Collections.Generic;
using ElectricHead.GameVc.TypeActivation;

namespace ElectricHead.GameVc.Routing
{
    public class SceneCache
    {
        private readonly IDependencyResolver _dependencyResolver;
        private readonly Dictionary<Type, IScene> _runningInstances;

        public SceneCache(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
            _runningInstances = new Dictionary<Type, IScene>();
        }

        public IScene For(Type sceneType)
        {
            if (!_runningInstances.ContainsKey(sceneType))
            {
                var instance = (IScene)_dependencyResolver.CreateInstance(sceneType);
                _runningInstances.Add(sceneType, instance);
            }

            return _runningInstances[sceneType];
        }
    }
}