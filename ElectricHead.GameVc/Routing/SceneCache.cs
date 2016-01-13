using System;
using System.Collections.Generic;

namespace ElectricHead.GameVc.Routing
{
    public class SceneCache
    {
        private readonly Func<Type, object> _createType;
        private readonly Dictionary<Type, IScene> _runningInstances;

        public SceneCache(Func<Type, object> createType)
        {
            _createType = createType;
            _runningInstances = new Dictionary<Type, IScene>();
        }

        public IScene For(Type sceneType)
        {
            if (!_runningInstances.ContainsKey(sceneType))
            {
                var instance = (IScene)_createType(sceneType);
                _runningInstances.Add(sceneType, instance);
            }

            return _runningInstances[sceneType];
        }
    }
}