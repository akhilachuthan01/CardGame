using CardGame.Models;
using CardGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services
{
    public class PlayerOperations : IPlayerOperations
    {
        public List<Player> CreatePlayers_DistributeCards(int numberOfPlayers, Deck playingDeck)
        {
            List<Player> players = new List<Player>();
            foreach (int i in Enumerable.Range(0, numberOfPlayers))
            {
                Player player = new Player() { Name = $"Player { i + 1 }", Cards = new List<Card>() };
                for (int c = 0; c < 3; c++)
                {
                    player.Cards.Add(playingDeck.CardStack.Pop());
                }
                players.Add(player);
            }
            return players;
        }

        public void ShowCards(List<Player> players)
        {
            foreach (var player in players)
            {
                Console.WriteLine($"Player Name: {player.Name}");
                Console.WriteLine("Cards are:");
                foreach (var card in player.Cards)
                {
                    Console.WriteLine(((CardNumberType)card.Number).ToString());
                }
            }
        }
    }
}
