using CardGame.Services.Rules;
using System.Linq;
using Xunit;

namespace CardGame.Services.Tests.Rules
{
    public class PairTests
    {
        [Fact]
        public void FoundWinner_Failed()
        {
            //Since the deck is not shuffled the no chance for a the same card in cardStack
            var cardStack = DeckOperations.GetDeckWithCards().Take(4).ToList();
            Assert.False(new Pair().IsPassed(cardStack));
        }

        [Fact]
        public void FoundWinner_Passed()
        {
            var cardStack = DeckOperations.GetDeckWithCards().Take(4).ToList();
            cardStack.Add(cardStack[0]);
            Assert.True(new Pair().IsPassed(cardStack));
        }
    }
}
