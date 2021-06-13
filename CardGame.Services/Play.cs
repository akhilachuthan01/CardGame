using CardGame.Common.Extensions;
using CardGame.Models;
using CardGame.Services.Interfaces;
using CardGame.Services.Rules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Services
{
    public class Play
    {
        private readonly IPlayerOperations _PlayerOperations;
        public Play(int numberOfPlayers, List<IRule> rules)
        {
            Players = new List<Player>();
            Rules = new List<IRule>();
            PlayingDeck = new Deck();
            NumberOfPlayers = numberOfPlayers;
            Rules.AddRange(rules);
            _PlayerOperations = new PlayerOperations();
        }

        public List<Player> Players { get; set; }
        public List<IRule> Rules { get; set; }
        public Deck PlayingDeck { get; set; }
        public int NumberOfPlayers { get; set; }

        public string StartGame()
        {
            PlayingDeck.CardStack = DeckOperations.GetDeckWithCards();
            PlayingDeck.CardStack.Shuffle();
            Players = _PlayerOperations.CreatePlayers_DistributeCards(NumberOfPlayers, PlayingDeck);
            _PlayerOperations.ShowCards(Players);

            List<Player> winners = Players;

            foreach (var rule in Rules)
            {
                List<Player> newWinners = new List<Player>();
                foreach (var player in Players)
                {
                    if (rule.IsPassed(player.Cards))
                    {
                        newWinners.Add(player);
                    }
                }
                if (newWinners.Count == 1)
                {
                    return $"{newWinners.FirstOrDefault().Name} is winner by {rule.Name} rule";
                }
                else if (newWinners.Count > 1)
                {
                    break;
                }
            }

            winners = GetWinnerUsingTopCard(winners);
            if (winners.Count == 1)
            {
                return $"{winners.FirstOrDefault().Name} is winner by top card rule";
            }
            return "It's a Tie";
        }

        private List<Player> GetWinnerUsingTopCard(List<Player> winners)
        {
            bool isFirst = true;
            //top card rule
            while (winners.Count > 1 && PlayingDeck.CardStack.Count > winners.Count)
            {
                List<Tuple<Player, int>> playersWithTopCard = new List<Tuple<Player, int>>();
                if (isFirst)
                {
                    //on first loop check top card rule
                    //Make a tuple of all winners with their existing top card
                    playersWithTopCard = winners.Select(x =>
                        new Tuple<Player, int>(x, x.Cards.Max(i => i.Number))).ToList();
                    isFirst = false;
                }
                else
                {
                    //check for final rule
                    foreach (var player in winners)
                    {
                        playersWithTopCard.Add(new Tuple<Player, int>(player, PlayingDeck.CardStack.Pop().Number));
                    }
                }
                winners = new TopCard().FoundWinner(playersWithTopCard);
            }

            return winners;
        }
    }
}
