using System;

namespace KtEquatable.Unit.Tests
{
    public static class TestSyntaxHelper
    {
        public delegate string ComparerSyntax(Type type);

        public static ComparerSyntax UnorderedComparerSyntax(bool isNew, ComparerSyntax comparerSyntaxOfValue)
        {
            if (isNew)
            {
                return type =>
                    $"new UnorderedEqualityComparer<{type.GetFriendlyNameAndAttributes()}>({comparerSyntaxOfValue(type.GetLastParam())})";
            }
            return type =>
                $"UnorderedEqualityComparer<{type.GetFriendlyNameAndAttributes()}>.Default";
        }

        public static ComparerSyntax SetComparerSyntax(bool isNew, ComparerSyntax comparerSyntaxOfValue)
        {
            if (isNew)
            {
                return type =>
                    $"new SetEqualityComparer<{type.GetFriendlyNameAndAttributes()}>({comparerSyntaxOfValue(type.GetLastParam())})";
            }
            return (Type type) =>
                $"SetEqualityComparer<{type.GetFriendlyNameAndAttributes()}>.Default";
        }

        public static ComparerSyntax OrderedComparerSyntax(bool isNew, ComparerSyntax comparerSyntaxOfValue)
        {
            if (isNew)
            {
                return type =>
                    $"new OrderedEqualityComparer<{type.GetFriendlyNameAndAttributes()}>({comparerSyntaxOfValue(type.GetLastParam())})";
            }
            return (Type type) =>
                $"OrderedEqualityComparer<{type.GetFriendlyNameAndAttributes()}>.Default";
        }

        public static ComparerSyntax DictionaryComparerSyntax(bool isNew, ComparerSyntax comparerSyntaxOfValue)
        {
            if (isNew)
            {
                return type =>
                    $"new DictionaryEqualityComparer<{type.GetFriendlyNameAndAttributes()}>({comparerSyntaxOfValue(type.GetLastParam())})";
            }
            return (Type type) =>
                $"DictionaryEqualityComparer<{type.GetFriendlyNameAndAttributes()}>.Default";
        }

        public static ComparerSyntax ReferenceComparerSyntax => (Type type) =>
                  $"ReferenceEqualityComparer<{type.GetFriendlyName()}>.Default";

        public static ComparerSyntax Basic => (Type type) =>
         $"EqualityComparer<{type.GetFriendlyName()}>.Default";

        public static ComparerSyntax FloatComparerSyntax(int precision) => (Type _) =>
        $"new FloatingPointEqualityComparer({precision})";
    }
}