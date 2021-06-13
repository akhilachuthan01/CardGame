using CardGame.Models;
using CardGame.Services.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CardGame.Services.Tests.Rules
{
    public class TopCardTests
    {
        [Fact]
        public void FoundWinner_SinglePlayer()
        {

            Stack<Card> cardStack = new Stack<Card>();
            cardStack.Push(new Card(1, 1));
            cardStack.Push(new Card(12, 1));
            cardStack.Push(new Card(3, 1));
            cardStack.Push(new Card(4, 1));

            List<Tuple<Player, int>> playersWithTopCard = new List<Tuple<Player, int>>()
            {
                new Tuple<Player, int>(new Player(){ Name = "Player 1" }, cardStack.Pop().Number),
                new Tuple<Player, int>(new Player(){ Name = "Player 2" }, cardStack.Pop().Number),
                new Tuple<Player, int>(new Player(){ Name = "Player 3" }, cardStack.Pop().Number),
                new Tuple<Player, int>(new Player(){ Name = "Player 4" }, cardStack.Pop().Number)
            };
            var winners = new TopCard().FoundWinner(playersWithTopCard);
            Assert.Equal("Player 3", winners.FirstOrDefault().Name);
            Assert.Single(winners);
        }

        [Fact]
        public void FoundWinner_MultiplePlayer()
        {

            Stack<Card> cardStack = new Stack<Card>();
            cardStack.Push(new Card(5, 1));
            cardStack.Push(new Card(6, 1));
            cardStack.Push(new Card(3, 1));
            cardStack.Push(new Card(12, 1));

            Card sameCard = cardStack.Pop();
            List<Tuple<Player, int>> playersWithTopCard = new List<Tuple<Player, int>>()
            {
                new Tuple<Player, int>(new Player(){ Name = "Player 1" }, sameCard.Number),
                new Tuple<Player, int>(new Player(){ Name = "Player 2" }, sameCard.Number),
                new Tuple<Player, int>(new Player(){ Name = "Player 3" }, cardStack.Pop().Number),
                new Tuple<Player, int>(new Player(){ Name = "Player 4" }, cardStack.Pop().Number)
            };
            var winners = new TopCard().FoundWinner(playersWithTopCard);
            Assert.Equal("Player 1", winners.FirstOrDefault().Name);
            Assert.Equal(2, winners.Count);
        }
    }
}
