using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NUnit.Framework;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.GameVc.Rendering;

namespace StarCrucible.Test.Unit.GameVc.ControlFlow
{
    [TestFixture]
    public class SceneRegistryTests
    {
        [Test]
        public void Register_GivenBothSceneAndRenderer_AddsToRegistry()
        {
            var registry = new SceneRegistry();

            registry.Register<TestScene, TestSceneRenderer>();

            Assert.That(registry.Scenes.Count, Is.EqualTo(1));
            Assert.That(registry.Renderers.Count, Is.EqualTo(1));
        }

        [Test]
        public void Register_GivenBothSceneAndRenderer_AddsSceneAndDetectsDefaultRenderer()
        {
            var registry = new SceneRegistry();

            registry.Register<TestScene>();

            Assert.That(registry.Scenes.Count, Is.EqualTo(1));
            Assert.That(registry.Renderers.Count, Is.EqualTo(1));
        }


    }

    public class TestScene : Scene
    {
    }

    public class TestSceneRenderer : IRenderAScene
    {
        public bool Supports(IScene scene) { throw new NotImplementedException(); }
        public void Draw(Game game, IScene current, GameTime gameTime) { throw new NotImplementedException(); }
    }
}
