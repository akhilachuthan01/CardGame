using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services
{
    public class Play
    {
        public List<Player> Players { get; set; }
        public List<Rule> Rules { get; set; }
        public Deck Deck { get; set; }
        public int NumberOfPlayers { get; set; }

        public string StartGame()
        {
            foreach (int i in Enumerable.Range(0, NumberOfPlayers))
            {
                Player player = new Player() { Name = $"Player { i + 1 }", Cards = new List<Card>() };
                for (int c = 0; c < 3; c++)
                {
                    player.Cards.Add(Deck.CardStack.Pop());
                }
                Players.Add(player);
            }

            List<Player> winners = Players;

            foreach (var rule in Rules)
            {
                var newWinners = rule.FoundWinner(winners);
                if (newWinners.Count == 1)
                {
                    return $"{newWinners.FirstOrDefault().Name} is winner";
                }
                else if (newWinners.Count > 1)
                {
                    winners = newWinners;
                }
            }

            //final rule
            while (winners.Count > 1 && Deck.CardStack.Count > winners.Count)
            {
                List<Tuple<Player, int>> finalPlayers = new List<Tuple<Player, int>>();
                foreach (var player in winners)
                {
                    finalPlayers.Add(new Tuple<Player, int>(player, Deck.CardStack.Pop().Number));
                }
                int newTopCard = finalPlayers.Max(i => i.Item2);
                winners = finalPlayers.Where(i => i.Item2 == newTopCard).Select(x => x.Item1).ToList();
            }
            if (winners.Count == 1)
            {
                return $"{winners.FirstOrDefault().Name} is winner";
            }
            return "It's a Tie";
        }
    }
}
