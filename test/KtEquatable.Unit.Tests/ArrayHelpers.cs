using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtEquatable.Unit.Tests
{
    public static class ArrayHelpers
    {
        /// <summary>
        /// Make a value tuple array for 2 Enumerables by making a matching table out of them
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="enum1"></param>
        /// <param name="enum2"></param>
        /// <returns></returns>
        public static IEnumerable<(T1 a, T2 b)> Tabulate<T1, T2>(this IEnumerable<T1> enum1, IEnumerable<T2> enum2)
        {
            foreach (var item1 in enum1)
            {
                foreach (var item2 in enum2)
                {
                    yield return (item1, item2);
                }
            }
        }
    }
}
