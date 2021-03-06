using System.Linq;

namespace ElectricHead.GameVc.Routing
{
    public class DefaultSceneSelectionStrategy : ISceneSelectionStrategy
    {
        public string SelectStartScene(SceneRouteTable routeTable)
        {
            return SelectStartScene(routeTable.Scenes.Select(x => x.Name).ToArray());
        }

        public string SelectStartScene(params string[] options)
        {
            foreach (var stub in new[] { "Default", "Splash", "Home", "Start" })
            {
                var scene = stub + "Scene";
                var screen = stub + "Screen";

                var knownStartScene = options.FirstOrDefault(x => x.ToLower() == scene.ToLower() || x.ToLower() == screen.ToLower());
                if (knownStartScene != null)
                {
                    return knownStartScene;
                }
            }

            return options.First();
        }
    }
}