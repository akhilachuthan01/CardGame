using CardGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services.Rules
{
    public class Sequence : Rule
    {
        public override List<Player> FoundWinner(List<Player> players)
        {
            List<Player> result = new List<Player>();
            foreach (var player in players)
            {
                foreach (Card card in player.Cards)
                {
                    //if three cards are concecutive, 
                    //then the absolute difference between a card and other two will be one.
                    //In case of Sequence Ace, Two and Three the difference between ace and two will be 12
                    if (player.Cards.Where(i => Math.Abs(i.Number - card.Number) == 1
                                                || Math.Abs(i.Number - card.Number) == 12).Count() == 2)
                    {
                        result.Add(player);
                        break;
                    }
                }
            }
            return result;
        }
    }
}
