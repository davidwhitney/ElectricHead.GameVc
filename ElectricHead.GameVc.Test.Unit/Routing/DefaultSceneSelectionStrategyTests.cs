using ElectricHead.GameVc.Routing;
using ElectricHead.GameVc.Test.Unit.SceneRegistration;
using ElectricHead.GameVc.Test.Unit.SceneRegistration.DetectionTestTypes;
using NUnit.Framework;

namespace ElectricHead.GameVc.Test.Unit.Routing
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
        public void SelectDefaultScene_GivenPopulatedRegistry_FindsSceneWithReservedName(string correctChoice)
        {
            var strategy = new DefaultSceneSelectionStrategy();

            var selection = strategy.SelectStartScene("TestScene", correctChoice, "RandomScene", "JunkScene");

            Assert.That(selection, Is.EqualTo(correctChoice));
        }

        [Test]
        public void SelectDefaultScene_GivenRegistryWithNoReservedNames_ReturnsFirstEntry()
        {
            var registry = new SceneRouteTable();
            registry.Scenes.Add(typeof(TestScene));
            registry.Scenes.Add(typeof(RandomScene));

            var start = new DefaultSceneSelectionStrategy().SelectStartScene(registry);

            Assert.That(start, Is.EqualTo("TestScene"));
        }
    }
}
