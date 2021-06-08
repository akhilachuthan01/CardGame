using System.Collections.Generic;

namespace CardGame.Models
{
    public abstract class Rule
    {
        public string Name { get; set; }
        public abstract List<Player> FoundWinner(List<Player> players);
    }
}
