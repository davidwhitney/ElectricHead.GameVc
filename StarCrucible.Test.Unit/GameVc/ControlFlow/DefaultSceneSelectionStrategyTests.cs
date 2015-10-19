﻿using NUnit.Framework;
using StarCrucible.GameVc.ControlFlow;
using StarCrucible.Test.Unit.GameVc.ControlFlow.DetectionTestTypes;

namespace StarCrucible.Test.Unit.GameVc.ControlFlow
{
    [TestFixture]
    public class DefaultSceneSelectionStrategyTests
    {
        [TestCase("HomeScene")]
        [TestCase("HomeScreen")]
        [TestCase("DefaultScene")]
        [TestCase("DefaultScreen")]
        [TestCase("StartScene")]
        [TestCase("StartScreen")]
        [TestCase("SplashScene")]
        [TestCase("SplashScreen")]
        public void SelectDefaultScene_GivenPopulatedRegistry_FindsDefault(string correctChoice)
        {
            var strategy = new DefaultSceneSelectionStrategy();

            var selection = strategy.SelectStartScene("TestScene", correctChoice, "RandomScene", "JunkScene");

            Assert.That(selection, Is.EqualTo(correctChoice));
        }

        [Test]
        public void SelectDefaultScene_GivenPopulatedRegistry_FindsDefault()
        {
            var registry = new SceneRegistry();
            registry.Scenes.Add(typeof(TestScene));
            registry.Scenes.Add(typeof(HomeScene));
            registry.Scenes.Add(typeof(RandomScene));

            var start = new DefaultSceneSelectionStrategy().SelectStartScene(registry);

            Assert.That(start, Is.EqualTo("HomeScene"));
        }
    }
}
