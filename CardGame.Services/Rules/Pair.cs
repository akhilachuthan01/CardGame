using CardGame.Models;
using CardGame.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class Pair : IRule
    {
        public string Name => "Pair";

        public bool IsPassed(List<Card> cards)
        {
            return cards.GroupBy(x => x.Number).Any(i => i.Count() == 2);
        }
    }
}
