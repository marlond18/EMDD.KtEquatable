using EMDD.KtEquatable.Syntax;

using Microsoft.CodeAnalysis.Text;

using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Text;

namespace EMDD.KtEquatable.Core.EqualityComparers
{
    public static class EqualityComparerWriter
    {
        private static SourceText Write(Action<IndentedTextWriter> writer)
        {
            var strWriter = new StringWriter();
            var i = new IndentedTextWriter(strWriter, "\t");
            writer(i);
            return SourceText.From(strWriter.ToString(), Encoding.UTF8);
        }

        public static SourceText DictionaryEqualityComparer()
        {
            return Write(i =>
            {
                i.WriteLine("using System.Collections;");
                i.WriteLine("using System.Collections.Generic;");
                i.WriteLine("using System.Linq;");
                i.WriteLine();
                i.WriteLine("#nullable enable");
                i.WriteMethod("namespace EMDD.KtEquatable.Core.EqualityComparers", i1 =>
                {
                    i1.WriteMethod("internal abstract class EnumerableEqualityComparer<T, TValue> : IEqualityComparer<T?> where T : IEnumerable?", i2 =>
                    {
                        i2.WriteLine("protected readonly IEqualityComparer<TValue> _valueComparer;");
                        i2.WriteLine();
                        i2.WriteLine("protected EnumerableEqualityComparer(IEqualityComparer<TValue> valueComparer)");
                        i2.WriteInsideBracket("_valueComparer = valueComparer;");
                        i2.WriteLine();
                        i2.WriteLine("public abstract bool Equals(T? x, T? y);");
                        i2.WriteLine("public abstract int GetHashCode(T? obj);");
                    });
                    i1.WriteLine();
                    i1.WriteMethod("internal class DictionaryEqualityComparer<TSource, TKey, TValue> : EnumerableEqualityComparer<TSource?, TValue> where TSource : IDictionary<TKey, TValue>?", i2 =>
                    {
                        i2.WriteMethod("public DictionaryEqualityComparer(IEqualityComparer<TValue> valueComparer) : base(valueComparer)");
                        i2.WriteLine();
                        i2.WriteLine("public static DictionaryEqualityComparer<TSource?, TKey, TValue> Default => new(EqualityComparer<TValue>.Default);");
                        i2.WriteLine();
                        i2.WriteMethod("public override bool Equals(TSource? x, TSource? y)", i3 =>
                        {
                            i3.WriteLine("if (ReferenceEquals(x, y)) return true;");
                            i3.WriteLine("if (x == null || y == null) return false;");
                            i3.WriteLine("if (x.Count != y.Count) return false;");
                            i3.WriteMethod("foreach (var pair in x)", i4 =>
                            {
                                i4.WriteLine("if (!y.TryGetValue(pair.Key, out var yValue)) return false;");
                                i4.WriteLine("if (!_valueComparer.Equals(pair.Value, yValue)) return false;");
                            });
                            i3.WriteLine("return true;");
                        });
                        i2.WriteLine();
                        i2.WriteLine("public override int GetHashCode(TSource? obj)");
                        i2.WriteInsideBracket("return (obj?.Aggregate(0, (hashCode, t) => hashCode ^ ((EqualityComparer<TKey>.Default.GetHashCode(t.Key) + _valueComparer.GetHashCode(t.Value)) & 0x7FFFFFFF))) ?? 0; ");
                    });
                    i1.WriteLineNoTabs("#nullable restore");
                });
            });
        }

        public static SourceText FloatingPointEqualityComparer()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine("using System.Collections.Generic;");
                i.WriteLine();
                i.WriteMethod("namespace EMDD.KtEquatable.Core.EqualityComparers", i1 =>
                {
                    i1.WriteMethod("internal class FloatingPointEqualityComparer : IEqualityComparer<double>", i2 =>
                    {
                        i2.WriteLine("private readonly int precision;");
                        i2.WriteLine();
                        i2.WriteLine("public FloatingPointEqualityComparer(int precision)");
                        i2.WriteInsideBracket("this.precision = precision;");
                        i2.WriteLine();
                        i2.WriteLine("public bool Equals(double x, double y)");
                        i2.WriteInsideBracket("return x.NearEquals(y, precision);");
                        i2.WriteLine();
                        i2.WriteLine("public int GetHashCode(double obj)");
                        i2.WriteInsideBracket("return obj.GetDoubleHashCode(precision);");
                        i2.WriteLine();
                    });
                });
            });
        }

        public static SourceText OrderedEqualityComparer()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine("using System.Collections.Generic;");
                i.WriteLine("using System.Linq;");
                i.WriteLine();
                i.WriteLine("#nullable enable");
                i.WriteMethod("namespace EMDD.KtEquatable.Core.EqualityComparers", i1 =>
                {
                    i1.WriteMethod("internal class OrderedEqualityComparer<TSource,T> : EnumerableEqualityComparer<TSource?, T> where TSource:IEnumerable<T>?", i2 =>
                    {
                        i2.WriteLine("public OrderedEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)");
                        i2.WriteInsideBracket("");
                        i2.WriteLine();
                        i2.WriteLine("public static OrderedEqualityComparer<TSource?,T> Default { get; } = new(EqualityComparer<T>.Default);");
                        i2.WriteLine();
                        i2.WriteMethod("public override bool Equals(TSource? x, TSource? y)", i3 =>
                        {
                            i3.WriteLine("if (ReferenceEquals(x, y)) return true;");
                            i3.WriteLine("if (x is null || y is null) return false;");
                            i3.WriteLine("return x.SequenceEqual(y, _valueComparer);");
                        });
                        i2.WriteLine();
                        i2.WriteMethod("public override int GetHashCode(TSource? obj)", i3 =>
                        {
                            i3.WriteLine("if (obj == null) return 0;");
                            i3.WriteLine("var hashCode = new HashCode();");
                            i3.WriteLine("foreach (var item in obj)");
                            i3.WriteInsideBracket("hashCode.Add(item, _valueComparer);");
                            i3.WriteLine("return hashCode.ToHashCode();");
                        });
                    });
                    i1.WriteLineNoTabs("#nullable restore");
                });
            });
        }

        public static SourceText ReferenceEqualityComparer()
        {
            return Write(i =>
            {
                i.WriteLine("using System.Collections.Generic;");
                i.WriteLine("using System.Runtime.CompilerServices;");
                i.WriteLine();
                i.WriteMethod("namespace EMDD.KtEquatable.Core.EqualityComparers", i1 =>
                {
                    i1.WriteLineNoTabs("#nullable enable");
                    i1.WriteMethod("internal class ReferenceEqualityComparer<T> : IEqualityComparer<T> where T : class?", i2 =>
                    {
                        i2.WriteLine("public static ReferenceEqualityComparer<T> Default => new();");
                        i2.WriteLine();
                        i2.WriteLine("public bool Equals(T? x, T? y) => ReferenceEquals(x, y);");
                        i2.WriteLine();
                        i2.WriteLineNoTabs("#pragma warning disable RS1024 // Compare symbols correctly");
                        i2.WriteLine("public int GetHashCode(T? obj) => RuntimeHelpers.GetHashCode(obj);");
                        i2.WriteLineNoTabs("#pragma warning restore RS1024 // Compare symbols correctly");
                    });
                    i1.WriteLineNoTabs("#nullable restore");
                });
            });
        }

        public static SourceText SetEqualityComparer()
        {
            return Write(i =>
            {
                i.WriteLine("using System.Collections.Generic;");
                i.WriteLine("using System.Linq;");
                i.WriteLine();
                i.WriteMethod("namespace EMDD.KtEquatable.Core.EqualityComparers", i1 =>
                {
                    i1.WriteLineNoTabs("#nullable enable");
                    i1.WriteMethod("internal class SetEqualityComparer<TSource, T> : EnumerableEqualityComparer<TSource?, T> where TSource: IEnumerable<T>?", i2 =>
                    {
                        i2.WriteMethod("public SetEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)");
                        i2.WriteLine();
                        i2.WriteLine("public static SetEqualityComparer<TSource?,T> Default { get; } = new(EqualityComparer<T>.Default);");
                        i2.WriteLine();
                        i2.WriteMethod("public override bool Equals(TSource? x, TSource? y)", i3 =>
                        {
                            i3.WriteLine("if (ReferenceEquals(x, y)) return true;");
                            i3.WriteLine("if (x is null || y is null) return false;");
                            i3.WriteLine("if (x is ISet<T> xSet) return xSet.SetEquals(y);");
                            i3.WriteLine("if (y is ISet<T> ySet) return ySet.SetEquals(x);");
                            i3.WriteLine("return x.All(xVal => y.Any(yVal => _valueComparer.Equals(xVal, yVal))) && y.All(yVal => x.Any(xVal => _valueComparer.Equals(xVal, yVal)));");
                        });
                        i2.WriteLine();
                        i2.WriteLine("public override int GetHashCode(TSource? obj) => 0;");
                    });
                    i1.WriteLineNoTabs("#nullable restore");
                });
            });
        }

        public static SourceText UnorderedEqualityComparer()
        {
            return Write(i =>
            {
                i.WriteLine("using System;;");
                i.WriteLine("using System.Collections.Generic;");
                i.WriteLine("using System.Linq;");
                i.WriteLine();
                i.WriteMethod("namespace EMDD.KtEquatable.Core.EqualityComparers", i1 =>
                {
                    i1.WriteLineNoTabs("#nullable enable");
                    i1.WriteMethod("public class UnorderedEqualityComparer<TSource,T> : EnumerableEqualityComparer<TSource?, T> where TSource:IEnumerable<T>?", i2 =>
                    {
                        i2.WriteMethod("public UnorderedEqualityComparer(IEqualityComparer<T> valueComparer) : base(valueComparer)");
                        i2.WriteLine();
                        i2.WriteLine("public static UnorderedEqualityComparer<TSource?,T> Default { get; } = new(EqualityComparer<T>.Default);");
                        i2.WriteLine();
                        i2.WriteMethod("public override bool Equals(TSource? x, TSource? y)", i3 =>
                        {
                            i3.WriteLine("if (ReferenceEquals(x, y)) return true;");
                            i3.WriteLine("if (x is null || y is null) return false;");
                            i3.WriteLine("if (x.Count() != y.Count()) return false;");
                            i3.WriteLine("return x.All(xVal => y.Contains(xVal, _valueComparer)) && y.All(yVal => x.Contains(yVal, _valueComparer));");
                        });
                        i2.WriteLine();
                        i2.WriteMethod("public override int GetHashCode(TSource? obj) => 0;", "return (obj?.Aggregate(0, (hashCode, t) => t is null ? hashCode : hashCode ^ (_valueComparer.GetHashCode(t) & 0x7FFFFFFF))) ?? 0;");
                    });
                    i1.WriteLineNoTabs("#nullable restore");
                });
            });
        }
    }
}
