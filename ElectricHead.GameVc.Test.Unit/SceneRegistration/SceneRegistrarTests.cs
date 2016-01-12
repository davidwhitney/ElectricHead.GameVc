using System;
using ElectricHead.GameVc.ControlFlow;
using ElectricHead.GameVc.Rendering;
using ElectricHead.GameVc.Routing;
using ElectricHead.GameVc.SceneRegistration;
using ElectricHead.GameVc.Test.Unit.ControlFlow.DetectionTestTypes;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace ElectricHead.GameVc.Test.Unit.ControlFlow
{
    [TestFixture]
    public class SceneRegistrarTests
    {
        private SceneRouteTable _routeTable;
        private SceneRegistrar _registrar;

        [SetUp]
        public void SetUp()
        {
            _routeTable = new SceneRouteTable();
            _registrar = new SceneRegistrar(_routeTable);
        }

        [Test]
        public void Register_GivenBothSceneAndRenderer_AddsSceneAndDetectsDefaultRenderer()
        {
            _registrar.Register<TestScene>();

            Assert.That(_routeTable.Scenes[0], Is.EqualTo(typeof(TestScene)));
            Assert.That(_routeTable.Renderers[0], Is.TypeOf<TestSceneRenderer>());
        }

        [Test]
        public void RendereFor_GivenBothSceneAndRenderer_ReturnsCorrectRenderer()
        {
            _registrar.Register<TestScene>();

            var scene = new TestScene();
            var renderer = _routeTable.RendererFor(scene);

            Assert.That(renderer, Is.TypeOf<TestSceneRenderer>());
        }

        [Test]
        public void AutoRegister_GivenThisTestAssemblyAndNamespaceFilter_RegisteresScenesAndRenderers()
        {
            _registrar.RegisterScenesFromNamespaceContaining<TestScene>();

            Assert.That(_routeTable.Scenes[0], Is.EqualTo(typeof(TestScene)));
            Assert.That(_routeTable.Renderers[0], Is.TypeOf<TestSceneRenderer>());
        }
    }
    
    public class HomeScene : Scene { }
    public class RandomScene : Scene { }

    namespace DetectionTestTypes
    {
        public class TestScene : Scene
        {
        }

        public class TestSceneRenderer : IRenderAScene
        {
            public bool Supports(IScene scene)
            {
                throw new NotImplementedException();
            }

            public void Draw(RenderingContext context, IScene currentScene, GameTime now)
            {
                throw new NotImplementedException();
            }
        }
    }
}
