using CardGame.Models;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class Trail : Rule
    {
        public Trail()
        {
            Name = "Trail";
        }

        public override List<Player> FoundWinner(List<Player> players)
        {
            List<Player> result = new List<Player>();
            foreach (var player in players)
            {
                if (player.Cards.GroupBy(x => x.Number).Any(i => i.Count() == 3))
                {
                    result.Add(player);
                }
            }
            return result;
        }
    }
}
