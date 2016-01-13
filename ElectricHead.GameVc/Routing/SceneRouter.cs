using System;
using System.Linq;

namespace ElectricHead.GameVc.Routing
{
    public class SceneRouter : ISceneRouter
    {
        private readonly ISceneRouteTable _sceneRouteTable;
        private readonly SceneCache _cache;

        public IScene Current => _cache.For(_sceneRouteTable.Scenes.First());

        public SceneRouter(ISceneRouteTable routeTable, SceneCache cache)
        {
            _sceneRouteTable = routeTable;
            _cache = cache;
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

    }
}
