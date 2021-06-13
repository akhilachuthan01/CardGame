using CardGame.Models;
using CardGame.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class Trail : IRule
    {
        public string Name => "Trail";

        public bool IsPassed(List<Card> cards)
        {
            return cards.GroupBy(x => x.Number).Any(i => i.Count() == cards.Count);
        }
    }
}
