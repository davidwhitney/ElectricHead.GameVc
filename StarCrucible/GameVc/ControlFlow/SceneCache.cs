using System;
using System.Collections.Generic;

namespace StarCrucible.GameVc.ControlFlow
{
    public class SceneCache
    {
        private readonly Dictionary<Type, IScene> _runningInstances;
          
        public SceneCache()
        {
            _runningInstances = new Dictionary<Type, IScene>();
        }

        public IScene For(Type sceneType)
        {
            if (!_runningInstances.ContainsKey(sceneType))
            {
                var instance = (IScene)Activator.CreateInstance(sceneType);
                _runningInstances.Add(sceneType, instance);
            }

            return _runningInstances[sceneType];
        }
    }
}