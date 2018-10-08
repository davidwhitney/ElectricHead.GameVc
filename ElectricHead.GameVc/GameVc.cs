using System;
using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.ErrorHandling;
using ElectricHead.GameVc.Rendering;
using ElectricHead.GameVc.Routing;
using ElectricHead.GameVc.SceneRegistration;
using ElectricHead.GameVc.TypeActivation;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElectricHead.GameVc
{
    public class GameVc
    {
        public ISceneRouter Router { get; set; }
        public ISceneRouteTable SceneRouteTable { get; set; }
        public IRegisterScenes SceneRegistrar { get; set; }
        public IGlobalErrorHandler ErrorHandler { get; set; }
        public IDependencyResolver DependencyResolver { get; set; }
        public RenderingContext RenderingContext { get; set; }

        private readonly Game _theGame;
        private readonly GameLoop _gameLoop;

        public IScene CurrentScene => Router.Current;

        public GameVc(Game theGame, string contentDirectory = "Content")
        {
            _theGame = theGame;
            _theGame.Content.RootDirectory = contentDirectory;

            DependencyResolver = new ActivationShim(Activator.CreateInstance);
            SceneRouteTable = new SceneRouteTable();
            SceneRegistrar = new SceneRegistrar(SceneRouteTable);

            RenderingContext = new RenderingContext
            {
                Game = _theGame,
                GraphicsDevice = new GraphicsDeviceManager(theGame),
                ContentDirectory = contentDirectory
            };

            Router = new SceneRouter(SceneRouteTable, new SceneCache(DependencyResolver.CreateInstance), RenderingContext);

            _gameLoop = new GameLoop(theGame, Router,
                t => CurrentScene.PreUpdate(),
                t => CurrentScene.Update(t),
                t => CurrentScene.PostUpdate()
                );
        }

        public GameVc AutoregisterScenes()
        {
            SceneRegistrar.DiscoverAndRegisterScenes();
            return this;
        }

        public GameVc StartGame()
        {
            Router.RedirectTo(SceneRouteTable.DefaultScene());
            return this;
        }

        public void LoadContent()
        {
            RenderingContext.SpriteBatch = new SpriteBatch(_theGame.GraphicsDevice);
            Router.Current.LoadContent(RenderingContext);
        }

        public void Update(GameTime time)
        {
            try
            {
                _gameLoop.Invoke(time);
            }
            catch(Exception ex) when (ErrorHandler != null)
            {
                ErrorHandler.OnException(ex);
            }
        }

        public void Draw(GameTime time)
        {
            try
            {
                var rendererType = SceneRouteTable.RendererFor(Router.Current);
                var rendererInstance = rendererType == Router.Current.GetType()
                    ? Router.Current
                    : DependencyResolver.CreateInstance(rendererType);

                var proxy = new RenderASceneProxy(rendererInstance);
                proxy.Draw(RenderingContext, CurrentScene, time);
            }
            catch (Exception ex) when (ErrorHandler != null)
            {
                ErrorHandler.OnException(ex);
            }
        }

        public GameVc OnError(Action<Exception> handler)
        {
            ErrorHandler = new ErrorActionHandler(handler);
            return this;
        }
    }
}
