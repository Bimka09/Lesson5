using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson5
{
    public static class Extensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, int> getParameter) where T : class
        {
            if (collection == null || !collection.Any())
            {
                throw new ArgumentException("Пустая коллекция");
            }

            var max = collection.First();

            for (var i = 1; i < collection.Count(); i++)
            {
                var current = collection.ElementAt(i);
                if (getParameter(current) > getParameter(max))
                {
                    max = current;
                }
            }
            return max;

        }

    }
}
