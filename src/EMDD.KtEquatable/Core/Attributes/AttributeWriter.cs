using Microsoft.CodeAnalysis.Text;

using static EMDD.KtEquatable.Syntax.SyntaxGenerators;

namespace EMDD.KtEquatable.Core.Attributes
{
    public static class AttributeWriter
    {
        public const string AttrNamespace = "EMDD.KtEquatable.Core.Attributes";
        public const string EquatableAttributeName = "EquatableAttribute";
        public const string EnumerableEqualityAttrName = "EnumerableEqualityAttribute";
        public const string FloatingPointEqualityAttrName = "FloatingPointEqualityAttribute";
        public const string IgnoreEqualityAttrName = "IgnoreEqualityAttribute";
        public const string ReferenceEqualityAttrName = "ReferenceEqualityAttribute";

        public static SourceText EquatableAttribute()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine();
                i.WriteMethod($"namespace {AttrNamespace}", i1 =>
                {
                    i1.WriteLine("[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]");
                    i1.WriteMethod($"internal class {EquatableAttributeName} : Attribute");
                });
            });
        }

        public static SourceText EnumerableEqualityAttribute()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine();
                i.WriteMethod($"namespace {AttrNamespace}", i1 =>
                {
                    i1.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
                    i1.WriteMethod($"internal class {EnumerableEqualityAttrName} : Attribute", i2 =>
                    {
                        i2.WriteMethod(
                            header: $"public {EnumerableEqualityAttrName}(EnumerableOrderType orderType = EnumerableOrderType.Unordered)",
                            content: "OrderType = orderType;");
                        i2.WriteLine();
                        i2.WriteLine("public EnumerableOrderType OrderType { get; }");
                    });
                    i1.WriteLine();
                    i1.WriteMethod("public enum EnumerableOrderType", i2 =>
                    {
                        i2.WriteLine("Unordered = 0,");
                        i2.WriteLine("Ordered = 1,");
                        i2.WriteLine("Set = 2,");
                    });
                });
            });
        }

        public static SourceText FloatingPointEqualityAttribute()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine();
                i.WriteMethod($"namespace {AttrNamespace}", i1 =>
                {
                    i1.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
                    i1.WriteMethod($"internal class {FloatingPointEqualityAttrName} : Attribute", i2 =>
                    {
                        i2.WriteLine("public int Precision { get; }");
                        i2.WriteLine();
                        i2.WriteMethod(
                            header: $"public {FloatingPointEqualityAttrName}(int precision = 10)",
                            content: "Precision = precision;");
                    });
                });
            });
        }

        public static SourceText IgnoreEqualityAttribute()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine();
                i.WriteMethod($"namespace {AttrNamespace}", i1 =>
                {
                    i1.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
                    i1.WriteMethod($"internal class {IgnoreEqualityAttrName} : Attribute");
                });
            });
        }

        public static SourceText ReferenceEqualityAttribute()
        {
            return Write(i =>
            {
                i.WriteLine("using System;");
                i.WriteLine();
                i.WriteMethod($"namespace {AttrNamespace}", i1 =>
                {
                    i1.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
                    i1.WriteMethod($"internal class {ReferenceEqualityAttrName} : Attribute");
                });
            });
        }
    }
}
