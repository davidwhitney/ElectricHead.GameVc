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

        public SceneCacheResult For(Type sceneType)
        {
            var requiresInitilisation = false;
            if (!_runningInstances.ContainsKey(sceneType))
            {
                var instance = (IScene)_createType(sceneType);
                requiresInitilisation = true;
                _runningInstances.Add(sceneType, instance);
            }

            return new SceneCacheResult
            {
                RequiresInitilisation = requiresInitilisation,
                Scene = _runningInstances[sceneType]
            };
        }
    }
}