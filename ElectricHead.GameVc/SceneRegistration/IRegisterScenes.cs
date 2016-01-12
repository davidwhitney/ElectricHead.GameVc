namespace ElectricHead.GameVc.SceneRegistration
{
    public interface IRegisterScenes
    {
        void RegisterScenesFromNamespaceContaining<T>();
        void DiscoverAndRegisterScenes(string @namespace = null);
        IRegisterScenes Register<TScene>() where TScene : IScene;
    }
}