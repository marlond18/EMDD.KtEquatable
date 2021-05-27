//#define LongTest

using EMDD.KtEquatable;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]

namespace KtEquatable.Unit.Tests
{
    public static class TestGeneratorHelper
    {
        public static (ImmutableArray<Diagnostic>, string) GetGeneratedOutput(string source)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(source);
            var references = AppDomain.CurrentDomain.GetAssemblies()
                .Where(_ => !_.IsDynamic && !string.IsNullOrWhiteSpace(_.Location))
                .Select(_ => MetadataReference.CreateFromFile(_.Location))
                .Concat(new[] { MetadataReference.CreateFromFile(typeof(EqualsGenerator).Assembly.Location) });
            var compilation = CSharpCompilation.Create("generator", new SyntaxTree[] { syntaxTree },
                references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            var originalTreeCount = compilation.SyntaxTrees.Length;
            var generator = new EqualsGenerator();
            var sss = new ResourceAttributeGenerator();

            var driver = CSharpGeneratorDriver.Create(ImmutableArray.Create<ISourceGenerator>(sss, generator));
            driver.RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out var diagnostics);

            var trees = outputCompilation.SyntaxTrees.ToList();
            var strResult = trees.Count != originalTreeCount ? trees[^1].ToString() : string.Empty;
            return (diagnostics, strResult);
        }

        public delegate string GetNameDelegate(Type type);

        public static GetNameDelegate[] GetTypeNameDelegates => new[] { GetCompleteTypeNameDelegate, GetFriendlyTypeNameDelegate };

        public static GetNameDelegate GetCompleteTypeNameDelegate => GetCompleteName;

        public static GetNameDelegate GetFriendlyTypeNameDelegate => GetFriendlyName;

        public static string GetCompleteName(this Type type)
        {
            if (type.IsArray)
            {
                var comma = type.GetArrayRank() - 1;
                return $"{type.GetElementType().GetCompleteName()}[{string.Concat(Enumerable.Repeat(",", comma)) }]";
            }
            if (type.IsGenericType)
            {
                return $"{type.FlatName().Split('`')[0]}<{string.Join(",", type.GetGenericArguments().Select(GetCompleteName))}>";
            }
            return type.FlatName();
        }

        public static (string name, string key, string val) GetDictionaryInfo(this Type type)
        {
            if (!type.IsGenericType) return (null, null, null);
            var baseName = type.FlatName().Split('`')[0];
            var args = type.GetGenericArguments();
            if (!baseName.Contains("Dictionary") || args.Length < 2) return (null, null, null);
            var argsText = string.Join(", ", args.Select(GetFriendlyName).ToArray());
            return (baseName + "<" + argsText + ">", args[0].GetFriendlyName(), args[1].GetFriendlyName());
        }

        public static Type GetLastParam(this Type type)
        {
            if (type.IsArray)
            {
                return type.GetElementType();
            }
            if (!type.IsGenericType) return null;
            var args = type.GetGenericArguments();
            return args[^1];
        }

        public static (string name, string[] param) GetGenericTypeInfo(this Type type)
        {
            if (type.IsArray)
            {
                var comma = type.GetArrayRank() - 1;
                var par = type.GetElementType().GetFriendlyName();
                return ($"{par}[{string.Concat(Enumerable.Repeat(",", comma)) }]", new[] { par });
            }
            if (!type.IsGenericType) return (null, null);
            var baseName = type.FlatName().Split('`')[0];
            var args = type.GetGenericArguments();
            var argsName = args.Select(GetFriendlyName).ToArray();
            var argsText = string.Join(", ", argsName);
            return (baseName + "<" + argsText + ">", argsName);
        }

        public static string GetFriendlyNameAndAttributes(this Type type)
        {
            if (type.IsArray)
            {
                var comma = type.GetArrayRank() - 1;
                var typeName = type.GetElementType().GetFriendlyName();
                return $"{typeName}[{string.Concat(Enumerable.Repeat(",", comma)) }], {typeName}";
            }
            if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(uint))
            {
                return "uint";
            }
            else if (type == typeof(nint))
            {
                return "nint";
            }
            else if (type == typeof(nuint))
            {
                return "nuint";
            }
            else if (type == typeof(short))
            {
                return "short";
            }
            else if (type == typeof(ushort))
            {
                return "ushort";
            }
            else if (type == typeof(byte))
            {
                return "byte";
            }
            else if (type == typeof(sbyte))
            {
                return "sbyte";
            }
            else if (type == typeof(bool))
            {
                return "bool";
            }
            else if (type == typeof(long))
            {
                return "long";
            }
            else if (type == typeof(ulong))
            {
                return "ulong";
            }
            else if (type == typeof(float))
            {
                return "float";
            }
            else if (type == typeof(double))
            {
                return "double";
            }
            else if (type == typeof(decimal))
            {
                return "decimal";
            }
            else if (type == typeof(string))
            {
                return "string";
            }
            else if (type == typeof(char))
            {
                return "char";
            }
            else if (type.IsGenericType)
            {
                var baseName = type.FlatName().Split('`')[0];
                var args = type.GetGenericArguments();
                if (baseName.Contains("Nullable") && args.Length == 1 && args[0].IsValueType)
                {
                    return $"{args[0].GetFriendlyName()}?";
                }
                var argsText = string.Join(", ", args.Select(GetFriendlyName).ToArray());
                return baseName + "<" + argsText + ">, " + argsText;
            }
            else
            {
                return type.FlatName();
            }
        }

        public static string GetFriendlyName(this Type type)
        {
            if (type.IsArray)
            {
                var comma = type.GetArrayRank() - 1;
                return $"{type.GetElementType().GetFriendlyName()}[{string.Concat(Enumerable.Repeat(",", comma)) }]";
            }
            if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(uint))
            {
                return "uint";
            }
            else if (type == typeof(nint))
            {
                return "nint";
            }
            else if (type == typeof(nuint))
            {
                return "nuint";
            }
            else if (type == typeof(short))
            {
                return "short";
            }
            else if (type == typeof(ushort))
            {
                return "ushort";
            }
            else if (type == typeof(byte))
            {
                return "byte";
            }
            else if (type == typeof(sbyte))
            {
                return "sbyte";
            }
            else if (type == typeof(bool))
            {
                return "bool";
            }
            else if (type == typeof(long))
            {
                return "long";
            }
            else if (type == typeof(ulong))
            {
                return "ulong";
            }
            else if (type == typeof(float))
            {
                return "float";
            }
            else if (type == typeof(double))
            {
                return "double";
            }
            else if (type == typeof(decimal))
            {
                return "decimal";
            }
            else if (type == typeof(string))
            {
                return "string";
            }
            else if (type == typeof(char))
            {
                return "char";
            }
            else if (type.IsGenericType)
            {
                var baseName = type.FlatName().Split('`')[0];
                var args = type.GetGenericArguments();
                if (baseName.Contains("Nullable") && args.Length == 1 && args[0].IsValueType)
                {
                    return $"{args[0].GetFriendlyName()}?";
                }
                return baseName + "<" + string.Join(", ", args.Select(GetFriendlyName).ToArray()) + ">";
            }
            else
            {
                return type.FlatName();
            }
        }

        private static string FlatName(this Type type)
        {
            return type.FullName.Replace('+', '.');
        }

        public static string GetCompleteName<T>()
        {
            return typeof(T).GetCompleteName();
        }

        public static string GetFriendlyName<T>()
        {
            return typeof(T).GetFriendlyName();
        }

        public static IEnumerable<Type> ListOfEnumerables(Type type)
        {
            yield return type.MakeArrayType();
            foreach (var bare in BareEnumerables())
            {
                yield return bare.MakeGenericType(type);
            }
        }

        public static IEnumerable<Type> BareEnumerables()
        {
            yield return typeof(IEnumerable<>);
            yield return typeof(List<>);
#if LongTest
            yield return typeof(IList<>);
            yield return typeof(ICollection<>);
            yield return typeof(IReadOnlyList<>);
            yield return typeof(IReadOnlyCollection<>);
            yield return typeof(Stack<>);
            yield return typeof(HashSet<>);
#endif 
        }

        public static IEnumerable<Type> ListOfDictionaries(Type typeKey, Type typeValue)
        {
            foreach (var dict in BareDictionaries())
            {
                yield return dict.MakeGenericType(new[] { typeKey, typeValue });
            }
        }

        public static IEnumerable<Type> BareDictionaries()
        {
            yield return typeof(Dictionary<,>);
#if LongTest
            yield return typeof(IDictionary<,>);
#endif
        }

        public static IEnumerable<Type> ListOfFloats()
        {
            yield return typeof(double);
#if LongTest
            yield return typeof(float);
            yield return typeof(float?);
            yield return typeof(double?);
#endif         
        }

        public static IEnumerable<Type> BasicClassTypes()
        {
            yield return typeof(string);
            yield return typeof(ClassTypeForTest);
        }

        public static IEnumerable<Type> NonClassTypes()
        {
            yield return typeof(bool);
            yield return typeof(double);
            yield return typeof(int);
#if LongTest
            yield return typeof(float);
            yield return typeof(byte);
            yield return typeof(char);
            yield return typeof(decimal);
            yield return typeof(uint);
            yield return typeof(ulong);
            yield return typeof(ushort);
            yield return typeof(sbyte);
            yield return typeof(short);
            yield return typeof(long);
#endif
            yield return typeof(nint);
            yield return typeof(EnumTypeForTest);
            yield return typeof(StructTypeForTest);
        }

        public static IEnumerable<Type> ListOfAllNonClass()
        {
#if LongTest
            return NonClassTypes().Concat(NonClassTypes().Select(MakeNullable));
#else
            return NonClassTypes();
#endif
        }

        public static IEnumerable<Type> ListOfNonFloat()
        {
#if LongTest
            return ListOfAllNonClass().Except(ListOfFloats()).Concat(BasicClassTypes());
#else
            return ListOfAllNonClass().Except(ListOfFloats());
#endif
        }

        public static Type MakeNullable(Type type)
        {
            var n = typeof(Nullable<>);
            return n.MakeGenericType(type);
        }
    }
}