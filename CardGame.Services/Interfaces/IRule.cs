using CardGame.Models;
using System.Collections.Generic;

namespace CardGame.Services.Interfaces
{
    public interface IRule
    {
        public string Name { get; }
        public abstract bool IsPassed(List<Card> cards);
    }
}
