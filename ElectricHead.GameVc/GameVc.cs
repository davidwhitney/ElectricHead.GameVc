﻿using ElectricHead.GameVc.ControlFlow;
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

        private readonly Game _theGame;

        private readonly GameLoop _gameLoop;
        private readonly RenderingContext _renderingContext;

        public GameVc(Game theGame, string contentDirectory = "Content")
        {
            _theGame = theGame;
            _theGame.Content.RootDirectory = contentDirectory;
            _renderingContext = new RenderingContext(theGame, new GraphicsDeviceManager(theGame));

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
            _gameLoop.Invoke(time);
        }

        public void Draw(GameTime time)
        {
            var renderer = SceneRouteTable.RendererFor(Router.Current);
            var context = _renderingContext.WithSceneAtTime(Router.Current, time);
            renderer.Draw(context);
        }
    }
}