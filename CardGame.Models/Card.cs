using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame.Models
{
    public class Card
    {
        public Card(int cardNumber, int symbol)
        {
            Number = cardNumber;
            Symbol = symbol;
        }

        public int Number { get; set; }

        public int Symbol { get; set; }
    }
}
