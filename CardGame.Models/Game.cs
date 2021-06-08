using System.Collections.Generic;

namespace CardGame.Models
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public List<Rule> Rules { get; set; }
    }
}
