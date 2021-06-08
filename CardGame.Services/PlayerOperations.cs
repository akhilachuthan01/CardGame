using CardGame.Models;
using System;
using System.Collections.Generic;

namespace CardGame.Services
{
    public static class PlayerOperations
    {
        public static void ShowCards(List<Player> players)
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
