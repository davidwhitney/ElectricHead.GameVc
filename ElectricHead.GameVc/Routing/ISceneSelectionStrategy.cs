namespace ElectricHead.GameVc.Routing
{
    public interface ISceneSelectionStrategy
    {
        string SelectStartScene(SceneRouteTable routeTable);
        string SelectStartScene(params string[] options);
    }
}