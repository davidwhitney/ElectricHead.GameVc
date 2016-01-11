using System;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Rendering;
using StarCrucible.Test.Unit.GameVc.ControlFlow.DetectionTestTypes;

namespace StarCrucible.Test.Unit.GameVc.ControlFlow
{
    [TestFixture]
    public class SceneRegistryTests
    {
        [Test]
        public void Register_GivenBothSceneAndRenderer_AddsSceneAndDetectsDefaultRenderer()
        {
            var registry = new SceneRegistry();

            registry.Register<TestScene>();

            Assert.That(registry.Scenes[0], Is.EqualTo(typeof(TestScene)));
            Assert.That(registry.Renderers[0], Is.TypeOf<TestSceneRenderer>());
        }

        [Test]
        public void RendereFor_GivenBothSceneAndRenderer_ReturnsCorrectRenderer()
        {
            var registry = new SceneRegistry().Register<TestScene>();

            var scene = new TestScene();
            var renderer = registry.RendererFor(scene);

            Assert.That(renderer, Is.TypeOf<TestSceneRenderer>());
        }

        [Test]
        public void AutoRegister_GivenThisTestAssemblyAndNamespaceFilter_RegisteresScenesAndRenderers()
        {
            var registry = new SceneRegistry();

            registry.AutoRegisterFromNamespaceContaining<TestScene>();

            Assert.That(registry.Scenes[0], Is.EqualTo(typeof(TestScene)));
            Assert.That(registry.Renderers[0], Is.TypeOf<TestSceneRenderer>());
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

            public void Draw(Game game, IScene current, GameTime gameTime)
            {
                throw new NotImplementedException();
            }
        }
    }
}
