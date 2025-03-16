using System.Collections.Generic;

namespace CardGame.Models
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
