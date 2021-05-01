
using Microsoft.CodeAnalysis;

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EMDD.KtSourceGen.KtEquatable.Core
{
    public static class CoreHelpers
    {
        public static string IndentAllLines(this string str, int currentTab)
        {
            var tab = currentTab > 0 ? string.Concat(Enumerable.Repeat("\t", currentTab)) : "";
            return tab + str.Replace("\n", $"\n{tab}");
        }

        public static string IndentNextLines(this string str, int currentTab)
        {
            var tab = currentTab > 0 ? string.Concat(Enumerable.Repeat("\t", currentTab)) : "";
            return str.Replace("\n", $"\n{tab}");
        }

        private static readonly Regex _escapeChar = new(@"[\<,\> ]");

        public static string ReplaceEscapeChars(this string s) => _escapeChar.Replace(s, "_");

        internal static string EqualsOperatorCodeComment =>
            @"/// <summary>
/// Indicates whether the object on the left is equal to the object on the right.
/// </summary>
/// <param name=""left"">The left object</param>
/// <param name=""right"">The right object</param>
/// <returns>true if the objects are equal; otherwise, false.</returns>";

        internal static string NotEqualsOperatorCodeComment =>
            @"/// <summary>
/// Indicates whether the object on the left is not equal to the object on the right.
/// </summary>
/// <param name=""left"">The left object</param>
/// <param name=""right"">The right object</param>
/// <returns>true if the objects are not equal; otherwise, false.</returns>";


        internal const string SourceGenName = "KtEquatable";

        internal static string GeneratedCodeAttributeDeclaration =>
            "[global::System.CodeDom.Compiler.GeneratedCodeAttribute(\"{NameSpace}\", \"1.0.0.0\")]";

        internal const string InheritDocComment = "/// <inheritdoc/>";

        public static string NameSpace => $"EMDD.KtSourceGen.{SourceGenName}";
    }
}
