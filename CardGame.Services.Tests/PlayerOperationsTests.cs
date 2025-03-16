using CardGame.Models;
using CardGame.Services.Interfaces;
using Xunit;

namespace CardGame.Services.Tests
{
    public class PlayerOperationsTests
    {
        [Fact]
        public void CreatePlayers_DistributeCards_Count()
        {
            var deck = new Deck();
            deck.CardStack = DeckOperations.GetDeckWithCards();

            var lastcard = deck.CardStack.Pop();
            deck.CardStack.Push(lastcard);
            IPlayerOperations playerOperations = new PlayerOperations();
            var players = playerOperations.CreatePlayers_DistributeCards(4, deck);

            Assert.Equal("Player 1", players[0].Name);
            Assert.Contains(lastcard, players[0].Cards);
            Assert.Equal(3, players[0].Cards.Count);
            Assert.Equal(4, players.Count);

        }
    }
}
