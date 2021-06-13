using CardGame.Models;
using System.Collections.Generic;

namespace CardGame.Services.Interfaces
{
    public interface IPlayerOperations
    {
        public List<Player> CreatePlayers_DistributeCards(int numberOfPlayers, Deck playingDeck);
        public void ShowCards(List<Player> players);
    }
}
