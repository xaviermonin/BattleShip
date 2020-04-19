using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip.Engine.Utils
{
    public static class ArrayExtension
    {
        public static IEnumerable<T> ToEnumerable<T>(this T[,] target)
        {
            foreach (var item in target)
                yield return item;
        }
    }
}
