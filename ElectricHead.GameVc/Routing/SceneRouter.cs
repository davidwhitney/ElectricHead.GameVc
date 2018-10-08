using System;
using System.Linq;

namespace ElectricHead.GameVc.Routing
{
    public class SceneRouter : ISceneRouter
    {
        private readonly ISceneRouteTable _sceneRouteTable;
        private readonly SceneCache _cache;
        private readonly RenderingContext _renderingContext;

        public IScene Current
        {
            get
            {
                var current = _cache.For(_sceneRouteTable.Scenes.First());
                if (current.RequiresInitilisation)
                {
                    current.Scene.LoadContent(_renderingContext);
                }

                return current.Scene;
            }
        }

        public SceneRouter(ISceneRouteTable routeTable, SceneCache cache, RenderingContext renderingContext)
        {
            _sceneRouteTable = routeTable;
            _cache = cache;
            _renderingContext = renderingContext;
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
