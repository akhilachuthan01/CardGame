using System;
using System.Collections.Generic;

namespace CardGame.Models
{
    public class Deck
    {
        private Stack<Card> _CardStack { get; set; }

        public Stack<Card> CardStack { get { return _CardStack; } }

        public Deck()
        {
            populateDeckWithCards();
        }

        private void populateDeckWithCards()
        {
            _CardStack = new Stack<Card>();
            foreach (int cardSymbol in Enum.GetValues(typeof(CardSymbol)))
            {
                foreach (int cardNumber in Enum.GetValues(typeof(CardNumberType)))
                {
                    _CardStack.Push(new Card(cardNumber, cardSymbol));
                }
            }
        }
    }
}
