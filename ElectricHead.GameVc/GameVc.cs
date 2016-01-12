using System;
using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.ErrorHandling;
using ElectricHead.GameVc.Routing;
using ElectricHead.GameVc.SceneRegistration;
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

        private readonly Game _theGame;
        private readonly GameLoop _gameLoop;
        private readonly RenderingContext _renderingContext;

        public GameVc(Game theGame, string contentDirectory = "Content")
        {
            _theGame = theGame;
            _theGame.Content.RootDirectory = contentDirectory;
            _renderingContext = new RenderingContext { Game = _theGame, GraphicsDevice = new GraphicsDeviceManager(theGame)};

            SceneRouteTable = new SceneRouteTable();
            SceneRegistrar = new SceneRegistrar(SceneRouteTable);
            Router = new SceneRouter(SceneRouteTable);

            _gameLoop = new GameLoop(theGame, Router,
                t => Router.Current.PreUpdate(),
                t => Router.Current.Update(t),
                t => Router.Current.PostUpdate()
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
            _renderingContext.SpriteBatch = new SpriteBatch(_theGame.GraphicsDevice);
            Router.Current.LoadContent();
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
                var renderer = SceneRouteTable.RendererFor(Router.Current);
                renderer.Draw(_renderingContext, Router.Current, time);
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
