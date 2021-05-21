using EMDD.KtEquatable.Core.Attributes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#nullable enable
namespace EMDD.KtEquatable.Core
{
    public static class ComparerHelpers
    {
        /// <summary>
        /// Determine if <paramref name="a"/> is near equal <paramref name="b"/> using the <paramref name="precision"/>
        /// </summary>
        /// <param name="a">first value comparison</param>
        /// <param name="b">second value in comparison</param>
        /// <param name="precision">numbers of decimal value to check</param>
        /// <returns></returns>
        public static bool NearEquals(this double a, double b, int precision) =>
            Math.Abs(a - b) < Math.Pow(10, -precision);

        /// <summary>
        /// Determine if <paramref name="a"/> is Content Equal to <paramref name="b"/>, Count should also be equal, if not then use <see cref="SetNearEquals{T}(T, T, int)"/>
        /// </summary>
        /// <typeparam name="T">should be <see cref="IEnumerable{Double}"/></typeparam>
        /// <param name="a">first collection</param>
        /// <param name="b">second collection</param>
        /// <param name="precision">decimal numbers to check</param>
        /// <returns></returns>
        public static bool ContentNearEquals<T>(this T? a, T? b, int precision) where T : IEnumerable<double>
        {
            if (a.Count() != b.Count()) return false;
            return a.All(val1 => b.Any(val2 => val2.NearEquals(val1, precision)))
                    && b.All(val1 => a.Any(val2 => val1.NearEquals(val2, precision)));
        }

        /// <summary>
        /// Determine if Two disctionaries are Equal by value
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static bool DictionaryEquals<TKey, TValue>(this IDictionary<TKey, TValue>? x, IDictionary<TKey, TValue>? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x == null || y == null) return false;
            if (x.Count != y.Count) return false;
            foreach (var pair in x)
            {
                if (!y.TryGetValue(pair.Key, out var yValue)) return false;
                if (!EqualityComparer<TValue>.Default.Equals(pair.Value, yValue)) return false;
            }
            return true;
        }

        /// <summary>
        /// Determine if <paramref name="a"/> is Sequence Equal to <paramref name="b"/>
        /// </summary>
        /// <typeparam name="T">should be <see cref="IEnumerable{Double}"/></typeparam>
        /// <param name="a">first collection</param>
        /// <param name="b">second collection</param>
        /// <param name="precision">decimal numbers to check</param>
        /// <returns></returns>
        public static bool SequenceNearEquals<T>(this T? a, T? b, int precision) where T : IEnumerable<double>
        {
            if (a.Count() != b.Count()) return false;
            var aList = a.ToList();
            var bList = b.ToList();
            for (int i = 0; i < aList.Count; i++)
            {
                if (!aList[i].NearEquals(bList[i], precision)) return false;
            }
            return true;
        }

        /// <summary>
        /// Determine if <paramref name="a"/> is Set Equal to <paramref name="b"/>
        /// </summary>
        /// <typeparam name="T">should be <see cref="IEnumerable{Double}"/></typeparam>
        /// <param name="a">first collection</param>
        /// <param name="b">second collection</param>
        /// <param name="precision">decimal numbers to check</param>
        /// <returns></returns>
        public static bool SetNearEquals<T>(this T? a, T? b, int precision) where T : IEnumerable<double>
        {
            return a.All(val1 => b.Any(val2 => val2.NearEquals(val1, precision)))
                    && b.All(val1 => a.Any(val2 => val1.NearEquals(val2, precision)));
        }

        public static int GetDoubleHashCode(this double val, int precision) =>
            (Math.Round(val * Math.Pow(10, precision), 0) / Math.Pow(10, precision)).GetHashCode();

        public static int GetSequenceDoubleHashCode<T>(this T? val, int precision) where T : IEnumerable<double>
        {
            if (val == null) return 0;
            var hashCode = new HashCode();
            foreach (var item in val)
            {
                hashCode.Add(item.GetDoubleHashCode(precision));
            }
            return hashCode.ToHashCode();
        }

        public static int GetContentDoubleHashCode<T>(this T? val, int precision) where T : IEnumerable<double>
        {
            return (val?.Aggregate(0, (hashCode, t) => hashCode ^ (t.GetDoubleHashCode(precision) & 0x7FFFFFFF))) ?? 0;
        }
    }
#nullable restore
}