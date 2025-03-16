using CardGame.Services.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CardGame.Services.Tests.Rules
{
    public class TrailTests
    {

        [Fact]
        public void IsPassed_Failed()
        {
            //Cards are not shuffled so the cards won't be same
            var cardStack = DeckOperations.GetDeckWithCards().Take(3).ToList();
            Assert.False(new Trail().IsPassed(cardStack));
        }

        [Fact]
        public void IsPassed_Passed()
        {
            var cardStack = DeckOperations.GetDeckWithCards().Take(1).ToList();
            cardStack.Add(cardStack[0]);
            cardStack.Add(cardStack[0]);
            Assert.True(new Trail().IsPassed(cardStack));
        }
    }
}
