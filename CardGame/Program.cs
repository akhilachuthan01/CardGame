using CardGame.Services;
using CardGame.Services.Interfaces;
using CardGame.Services.Rules;
using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRule> rules = new List<IRule>
            {
                new Trail(),
                new Sequence(),
                new Pair()
            };

            Play play = new Play(4, rules);

            Console.WriteLine("Press any key to start");
            Console.ReadKey();
            string result = play.StartGame();

            Console.WriteLine("---------------------------------");
            Console.WriteLine(result);
            Console.WriteLine("---------------------------------");

            Console.ReadKey();
        }
    }
}
