using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectricHead.GameVc.Routing
{
    public class SceneRouter : ISceneRouter
    {
        private readonly ISceneRouteTable _sceneRouteTable;
        private readonly SceneCache _cache;

        public IScene Current => _cache.For(_sceneRouteTable.Scenes.First());

        public SceneRouter(ISceneRouteTable routeTable)
        {
            _cache = new SceneCache();
            _sceneRouteTable = routeTable;
        }

        public SceneRouter StartWith<TScene>()
            where TScene : IScene
        {
            RedirectTo(typeof(TScene));
            return this;
        }
        
        public void RedirectTo(Type scene)
        {
            var offset = _sceneRouteTable.Scenes.IndexOf(scene);
            var sceneType = _sceneRouteTable.Scenes[offset];
            _sceneRouteTable.Scenes.RemoveAt(offset);
            _sceneRouteTable.Scenes.Insert(0, sceneType);
        }

        private class SceneCache
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
}
