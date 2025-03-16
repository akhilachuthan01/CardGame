using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Common.Extensions
{
    public static class StackExtensions
    {
        private static readonly Random rand = new Random();
        public static void Shuffle<T>(this Stack<T> stack)
        {
            T[] values = stack.ToArray();
            stack.Clear();
            foreach (T value in values.OrderBy(x => rand.Next()))
            {
                stack.Push(value);
            }
        }
    }
}
