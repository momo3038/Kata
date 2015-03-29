using NFluent;
using TechTalk.SpecFlow;

namespace GameOfLife.Spec
{
    [Binding]
    public class Steps
    {
        private Game _game;

        [Given(@"I have the following world")]
        public void GivenIHaveTheFollowingWorld(string world)
        {
            _game = new Game(world, new GameParser());
        }

        [When(@"I play god")]
        public void WhenIPlayGod()
        {
            _game.Play();
        }

        [Then(@"the world is now like that")]
        public void ThenTheWorldIsNowLikeThat(string world)
        {
            Check.That(_game.Display(new GameDisplayer())).IsEqualTo(world);
        }
    }
}
