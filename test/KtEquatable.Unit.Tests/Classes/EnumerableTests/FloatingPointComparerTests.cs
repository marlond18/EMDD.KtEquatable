using KtEquatable.Unit.Tests.Assertions;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.Assertions.AssertionHelpers;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Classes.EnumerableTests
{
    [TestClass]
    public class FloatingPointComparerTests
    {
        private const string propName = "P1";
        private const string className = "A";

        [TestMethod]
        [DynamicData(nameof(EnumerableDoubleNames), DynamicDataSourceType.Method)]
        public void EnumerableDouble(ISyntaxSource sourceClass, string comparerSyntax, TypeInfo<IPropertySymbol> diagnostic)
        {
            var testIfGeneratedString = GetGeneratedOutputAssertion(sourceClass);
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
            testIfGeneratedString.HasEqualsOperatorFor(className);
            testIfGeneratedString.HasPartialObjHeaderFor(className,sourceClass.InternalType, sourceClass.ImplementationOnGenCode);
            testIfGeneratedString.HasEqualityComparerFor(propName, comparerSyntax);
        }

        private static IEnumerable<object[]> EnumerableDoubleNames()
        {
            foreach (var precision in new[] { -1, 12, 20 })
            {
                var valueComparerSyntax = precision < 0 ? Basic : FloatComparerSyntax(precision);
                var floatAttr = FloatingPointAttr(precision);
                foreach (var (enumAttr, comparerSyntax) in new[] {
                (EnumerableSetAttr, SetComparerSyntax(true,valueComparerSyntax )),
                (EnumerableOrderedAttr, OrderedComparerSyntax(true,valueComparerSyntax)),
                (EnumerableUnorderedAttr, UnorderedComparerSyntax(true,valueComparerSyntax)) })
                {
                    var diag = precision < 0 ? FloatingPointPrecisionLessZero : null;
                    var attr = new[] { enumAttr, floatAttr };
                    foreach (var type in ListOfEnumerables(typeof(double?)))
                    {
                        var sourceProp = new SourceProperty(GetFriendlyTypeNameDelegate(type), propName, attr);
                        var sourceClass = new SourceClass(className, sourceProp);
                        var comparer = comparerSyntax(type);
                        yield return new object[] { sourceClass, comparer, diag };
                    }
                    foreach (var type in ListOfEnumerables(typeof(double)))
                    {
                        var comparer = comparerSyntax(type);
                        foreach (var propTypeName in new[] { GetFriendlyTypeNameDelegate(type), GetCompleteTypeNameDelegate(type) })
                        {
                            var sourceProp = new SourceProperty(propTypeName, propName, attr);
                            var sourceClass = new SourceClass(className, sourceProp);
                            yield return new object[] { sourceClass, comparer, diag };
                        }
                    }
                }
                foreach (var (enumAttr, comparerSyntax, diag) in new[] {
                (EnumerableSetAttr,Basic, DictionaryCantBeSetType),
                (EnumerableOrderedAttr,Basic, DictionaryCantBeOrderedType),
                (EnumerableUnorderedAttr,DictionaryComparerSyntax(true,valueComparerSyntax), null) })
                {
                    var diag2 = diag ?? (precision < 0 ? FloatingPointPrecisionLessZero : null);
                    var attr = new[] { enumAttr, floatAttr };
                    foreach (var type in ListOfDictionaries(typeof(string), typeof(double?)))
                    {
                        var sourceProp = new SourceProperty(GetFriendlyTypeNameDelegate(type), propName, attr);
                        var sourceClass = new SourceClass(className, sourceProp);
                        var comparer = comparerSyntax(type);
                        yield return new object[] { sourceClass, comparer, diag2 };
                    }
                    foreach (var type in ListOfDictionaries(typeof(string), typeof(double)))
                    {
                        var comparer = comparerSyntax(type);
                        foreach (var propTypeName in new[] { GetFriendlyTypeNameDelegate(type), GetCompleteTypeNameDelegate(type) })
                        {
                            var sourceProp = new SourceProperty(propTypeName, propName, attr);
                            var sourceClass = new SourceClass(className, sourceProp);
                            yield return new object[] { sourceClass, comparer, diag2 };
                        }
                    }
                }
            }
        }
    }
}