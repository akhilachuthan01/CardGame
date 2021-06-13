using CardGame.Models;
using CardGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class TopCard
    {
        public string Name => "Top Card";

        public List<Player> FoundWinner(IEnumerable<Tuple<Player, int>> playersWithTopCard)
        {
            int topCard = playersWithTopCard.Max(i => i.Item2);
            return playersWithTopCard.Where(i => i.Item2 == topCard).Select(x => x.Item1).ToList();
        }
    }
}
