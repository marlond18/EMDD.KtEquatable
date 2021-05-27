using Microsoft.CodeAnalysis.Text;

using System.CodeDom.Compiler;
using System.IO;
using System.Text;

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
            var strWriter = new StringWriter();
            var indented = new IndentedTextWriter(strWriter, "\t");
            indented.WriteLine("using System;");
            indented.WriteLine();
            indented.WriteLine($"namespace {AttrNamespace}");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]");
            indented.WriteLine($"internal class {EquatableAttributeName} : Attribute");
            indented.WriteLine("{");
            indented.WriteLine("}");
            indented.Indent--;
            indented.WriteLine("}");
            return SourceText.From(strWriter.ToString(), Encoding.UTF8);
        }

        public static SourceText EnumerableEqualityAttribute()
        {
            var strWriter = new StringWriter();
            var indented = new IndentedTextWriter(strWriter, "\t");
            indented.WriteLine("using System;");
            indented.WriteLine();
            indented.WriteLine($"namespace {AttrNamespace}");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
            indented.WriteLine($"internal class {EnumerableEqualityAttrName} : Attribute");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine($"public {EnumerableEqualityAttrName}(EnumerableOrderType orderType = EnumerableOrderType.Unordered)");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("OrderType = orderType;");
            indented.Indent--;
            indented.WriteLine("}");
            indented.WriteLine();
            indented.WriteLine("public EnumerableOrderType OrderType { get; }");
            indented.Indent--;
            indented.WriteLine("}");
            indented.WriteLine();
            indented.WriteLine("public enum EnumerableOrderType");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("Unordered = 0,");
            indented.WriteLine("Ordered = 1,");
            indented.WriteLine("Set = 2,");
            indented.Indent--;
            indented.WriteLine("}");
            indented.Indent--;
            indented.WriteLine("}");
            return SourceText.From(strWriter.ToString(), Encoding.UTF8);
        }

        public static SourceText FloatingPointEqualityAttribute()
        {
            var strWriter = new StringWriter();
            var indented = new IndentedTextWriter(strWriter, "\t");
            indented.WriteLine("using System;");
            indented.WriteLine();
            indented.WriteLine($"namespace {AttrNamespace}");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
            indented.WriteLine($"internal class {FloatingPointEqualityAttrName} : Attribute");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine($"public {FloatingPointEqualityAttrName}(int precision = 10)");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("Precision = precision;");
            indented.Indent--;
            indented.WriteLine("}");
            indented.WriteLine("public int Precision { get; }");
            indented.Indent--;
            indented.WriteLine("}");
            indented.Indent--;
            indented.WriteLine("}");
            return SourceText.From(strWriter.ToString(), Encoding.UTF8);
        }

        public static SourceText IgnoreEqualityAttribute()
        {
            var strWriter = new StringWriter();
            var indented = new IndentedTextWriter(strWriter, "\t");
            indented.WriteLine("using System;");
            indented.WriteLine();
            indented.WriteLine($"namespace {AttrNamespace}");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
            indented.WriteLine($"internal class {IgnoreEqualityAttrName} : Attribute");
            indented.WriteLine("{");
            indented.WriteLine("}");
            indented.Indent--;
            indented.WriteLine("}");
            return SourceText.From(strWriter.ToString(), Encoding.UTF8);
        }

        public static SourceText ReferenceEqualityAttribute()
        {
            var strWriter = new StringWriter();
            var indented = new IndentedTextWriter(strWriter, "\t");
            indented.WriteLine("using System;");
            indented.WriteLine();
            indented.WriteLine($"namespace {AttrNamespace}");
            indented.WriteLine("{");
            indented.Indent++;
            indented.WriteLine("[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]");
            indented.WriteLine($"internal class {ReferenceEqualityAttrName} : Attribute");
            indented.WriteLine("{");
            indented.WriteLine("}");
            indented.Indent--;
            indented.WriteLine("}");
            return SourceText.From(strWriter.ToString(), Encoding.UTF8);
        }
    }
}
