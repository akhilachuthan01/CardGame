using CardGame.Models;
using CardGame.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class Sequence : IRule
    {
        public string Name => "Sequence";

        public bool IsPassed(List<Card> cards)
        {
            if (new Pair().IsPassed(cards))
            {
                //if pair cards then it's not sequential
                return false;
            }

            foreach (Card card in cards)
            {
                //if three cards are concecutive, 
                //then the absolute difference between a card and other two will be one.
                //In case of Sequence Ace, Two and Three the difference between ace and two will be 12
                if (cards.Where(i => Math.Abs(i.Number - card.Number) == 1
                                            || Math.Abs(i.Number - card.Number) == 12).Count() == 2)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
