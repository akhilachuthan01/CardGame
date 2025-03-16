using CardGame.Services.Interfaces;
using CardGame.Services.Rules;
using System.Collections.Generic;
using Xunit;

namespace CardGame.Services.Tests
{
    public class PlayTests
    {
        [Fact]
        public void StartGame_Test()
        {
            List<IRule> rules = new List<IRule>
            {
                new Trail(),
                new Sequence(),
                new Pair()
            };

            Play play = new Play(4, rules);
            Assert.NotNull(play.StartGame());
        }
    }
}
