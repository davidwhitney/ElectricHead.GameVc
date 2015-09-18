using System;
using System.Collections.Generic;

namespace StarCrucible.GameVc.ControlFlow
{
    public class SceneCache
    {
        private readonly Dictionary<Type, ISceneController> _runningInstances;
          
        public SceneCache()
        {
            _runningInstances = new Dictionary<Type, ISceneController>();
        }

        public ISceneController For(Type sceneType)
        {
            if (!_runningInstances.ContainsKey(sceneType))
            {
                var instance = (ISceneController)Activator.CreateInstance(sceneType);
                _runningInstances.Add(sceneType, instance);
            }

            return _runningInstances[sceneType];
        }
    }
}