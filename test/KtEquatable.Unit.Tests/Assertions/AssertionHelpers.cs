
using Microsoft.CodeAnalysis;

using System.Linq;
using System.Text;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Assertions
{
    public static class AssertionHelpers
    {
        public static string EnumerableSetAttr => "EnumerableEquality(EnumerableOrderType.Set)";
        public static string EnumerableOrderedAttr => "EnumerableEquality(EnumerableOrderType.Ordered)";
        public static string EnumerableUnorderedAttr => "EnumerableEquality(EnumerableOrderType.Unordered)";
        public static string FloatingPointAttr(int precision) => $"FloatingPointEquality({precision})";
        public static string ReferenceAttr => "ReferenceEquality";
        public static string IgnoreAttr => "IgnoreEquality";

        public static string ObjectToString(this ISyntaxSource source)
        {
            var str = new StringBuilder();
            str.AppendLine("using EMDD.KtEquatable.Core.Attributes;");
            str.AppendLine("using System.Collections.Generic;");
            str.AppendLine("using System.Linq;");
            str.AppendLine();
            str.AppendLine("namespace Test");
            str.AppendLine("{");
            str.AppendLine("\t[Equatable]");
            str.Append("\tpublic partial ").Append(source.InternalType).Append(' ').AppendLine(source.ObjectName);
            str.AppendLine("\t{");
            str.AppendJoin("\n\n", source.Props.Select(p => p.PropToString())).AppendLine();
            str.AppendLine("\t}");
            str.Append('}');
            return str.ToString();
        }

        internal static IfGeneratedString GetGeneratedOutputAssertion(ISyntaxSource sourcesyntax)
        {
            var (diagnostics, output) = TestGeneratorHelper.GetGeneratedOutput(sourcesyntax.ObjectToString());
            return Test.IfGeneratedString(diagnostics, output);
        }

        internal static void AssertAGeneratedCode(this ISyntaxSource sourceObj, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic, string className, string propName, bool skipEqualityOpTest, bool forIgnoredAttr)
        {
            var testIfGeneratedString = GetGeneratedOutputAssertion(sourceObj);
            if (diagnostic is null)
            {
                testIfGeneratedString.HasNoDiagnostics();
            }
            else
            {
                testIfGeneratedString.IsDiagnosedWith(diagnostic);
            }
            testIfGeneratedString.HasNullableSyntax();
            testIfGeneratedString.HasCorrectUsingStatements();
            if (!skipEqualityOpTest) testIfGeneratedString.HasEqualsOperatorFor(className);
            testIfGeneratedString.HasPartialObjHeaderFor(className, sourceObj.InternalType, sourceObj.ImplementationOnGenCode);
            if (forIgnoredAttr)
            {
                testIfGeneratedString.HasEqualityComparerFor("OtherProp2", Basic(typeof(int)));
                testIfGeneratedString.IgnoresEqualityComparerFor(propName, comparerSyntax);
            }
            else
            {
                testIfGeneratedString.HasEqualityComparerFor(propName, comparerSyntax);
            }
        }
    }
}