using System;
using System.Net.Mime;
using ElectricHead.GameVc.Rendering;
using ElectricHead.GameVc.Routing;
using ElectricHead.GameVc.SceneRegistration;
using ElectricHead.GameVc.Test.Unit.SceneRegistration.DetectionTestTypes;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace ElectricHead.GameVc.Test.Unit.SceneRegistration
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
            Assert.That(_routeTable.Renderers[0], Is.EqualTo(typeof(TestSceneRenderer)));
        }

        [Test]
        public void RendereeFor_GivenBothSceneAndRenderer_ReturnsRenderingProxyToWorkAroundTypeConstraints()
        {
            _registrar.Register<TestScene>();

            var scene = new TestScene();
            var renderer = _routeTable.RendererFor(scene);

            Assert.That(renderer, Is.TypeOf<RenderingProxy>());
        }

        [Test]
        public void AutoRegister_GivenThisTestAssemblyAndNamespaceFilter_RegisteresScenesAndRenderers()
        {
            _registrar.RegisterScenesFromNamespaceContaining<TestScene>();

            Assert.That(_routeTable.Scenes[0], Is.EqualTo(typeof(TestScene)));
            Assert.That(_routeTable.Renderers[0], Is.EqualTo(typeof(TestSceneRenderer)));
        }
    }
    
    public class HomeScene : Scene { }
    public class RandomScene : Scene { }

    namespace DetectionTestTypes
    {
        public class TestScene : Scene
        {
        }

        public class TestSceneRenderer : IRenderAScene<TestScene>
        {
            public void Draw(RenderingContext context, TestScene currentScene, GameTime now)
            {
                throw new NotImplementedException();
            }

        }
    }
}
