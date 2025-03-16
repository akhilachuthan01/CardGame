using CardGame.Services.Rules;
using System.Linq;
using Xunit;

namespace CardGame.Services.Tests.Rules
{
    public class SequenceTests
    {
        [Fact]
        public void IsPassed_Passed()
        {
            //Cards are not shuffled so the cards wil be in sequential order
            var cardStack = DeckOperations.GetDeckWithCards().Take(4).ToList();
            Assert.True(new Sequence().IsPassed(cardStack));
        }

        [Fact]
        public void IsPassed_Failed()
        {
            var cardStack = DeckOperations.GetDeckWithCards().Take(4).ToList();
            //one card is removed
            cardStack.RemoveAt(0);
            //duplicate card is added
            cardStack.Add(cardStack[0]);

            Assert.False(new Sequence().IsPassed(cardStack));
        }
    }
}
