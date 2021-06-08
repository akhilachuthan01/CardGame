using CardGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class Pair : Rule
    {
        public Pair()
        {
            Name = "Pair";
        }

        public override List<Player> FoundWinner(List<Player> players)
        {
            List<Player> result = new List<Player>();
            foreach (Player player in players)
            {
                if (player.Cards.GroupBy(x => x.Number).Any(i => i.Count() == 2))
                {
                    result.Add(player);
                }
            }
            return result;
        }
    }
}
