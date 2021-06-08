using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class TopCard : Rule
    {
        public TopCard()
        {
            Name = "Top Card";
        }

        public override List<Player> FoundWinner(List<Player> players)
        {
            IEnumerable<Tuple<int, Player>> playersWithTopCard = players.Select(x => new Tuple<int, Player>(x.Cards.Max(i => i.Number), x));
            int topCard = playersWithTopCard.Max(i => i.Item1);
            return playersWithTopCard.Where(i => i.Item1 == topCard).Select(x => x.Item2).ToList();
        }
    }
}
