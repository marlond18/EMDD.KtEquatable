
using Microsoft.CodeAnalysis;

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using static EMDD.KtSourceGen.KtEquatable.Syntax.SyntaxGenerators;
namespace EMDD.KtEquatable.Core
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

        internal static string GeneratedCodeAttributeDeclaration => $"[GeneratedCodeAttribute(\"{NameSpace}\", \"{Version}\")]";

        internal const string InheritDocComment = "/// <inheritdoc/>";

        internal const string SourceGenName = "KtEquatable";

        public static string NameSpace => $"EMDD.{SourceGenName}";

        public const string Version = "2.0.2";

        public static string BuildUsingStatements(string[] toAdd)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.Append("using System.CodeDom.Compiler;");
            if (toAdd?.Length > 0)
            {
                sb.Append("\n").Append(string.Join("\n", toAdd));
            }
            return sb.ToString();
        }
    }
}