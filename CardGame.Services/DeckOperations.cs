using CardGame.Models;
using System;
using System.Collections.Generic;

namespace CardGame.Services
{
    public static class DeckOperations
    {
        public static Stack<Card> GetDeckWithCards()
        {
            var cardStack = new Stack<Card>();
            foreach (int cardSymbol in Enum.GetValues(typeof(CardSymbol)))
            {
                foreach (int cardNumber in Enum.GetValues(typeof(CardNumberType)))
                {
                    cardStack.Push(new Card(cardNumber, cardSymbol));
                }
            }
            return cardStack;
        }
    }
}
