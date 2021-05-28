using System.Text.RegularExpressions;
namespace EMDD.KtEquatable.Core
{
    public static class CoreHelpers
    {
        private static readonly Regex _escapeChar = new(@"[\<,\> ]");

        public static string ReplaceEscapeChars(this string s) => _escapeChar.Replace(s, "_");

        internal static string GeneratedCodeAttributeDeclaration => $"[GeneratedCodeAttribute(\"{NameSpace}\", \"{Version}\")]";

        internal const string InheritDocComment = "/// <inheritdoc/>";

        internal const string SourceGenName = "KtEquatable";

        public static string NameSpace => $"EMDD.{SourceGenName}";

        public const string Version = "3.2.0";
    }
}