using System.Collections.Generic;

namespace CardGame.Models
{
    public abstract class Rule
    {
        public abstract List<Player> FoundWinner(List<Player> players);
    }
}
