namespace ElectricHead.GameVc.ControlFlow
{
    public interface ISceneSelectionStrategy
    {
        string SelectStartScene(SceneRegistry registry);
        string SelectStartScene(params string[] options);
    }
}