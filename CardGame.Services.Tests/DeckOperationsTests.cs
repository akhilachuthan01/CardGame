using System.Collections.Generic;
using Xunit;

namespace CardGame.Services.Tests
{
    public class DeckOperationsTests
    {
        [Fact]
        public void GetDeckWithCards_Count()
        {
            Stack<Models.Card> deck = DeckOperations.GetDeckWithCards();
            Assert.Equal(52, deck.Count);
        }
    }
}
