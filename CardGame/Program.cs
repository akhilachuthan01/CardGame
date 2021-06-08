using CardGame.Common.Extensions;
using CardGame.Models;
using CardGame.Services;
using CardGame.Services.Rules;
using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Play play = new Play
            {
                Deck = new Deck(),
                NumberOfPlayers = 4,
                Rules = new List<Rule>(),
                Players = new List<Player>(),
            };
            play.Deck.CardStack = DeckOperations.GetDeckWithCards();
            play.Rules.Add(new Trail());
            play.Rules.Add(new Sequence());
            play.Rules.Add(new Pair());
            play.Rules.Add(new TopCard());

            play.Deck.CardStack.Shuffle();

            string result = play.StartGame();

            Console.WriteLine("---------------------------------");
            Console.WriteLine(result);
            Console.WriteLine("---------------------------------");

            Console.ReadKey();
        }
    }
}
