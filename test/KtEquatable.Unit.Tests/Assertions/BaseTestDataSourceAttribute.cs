
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Assertions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public abstract class BaseTestDataSourceAttribute : Attribute, ITestDataSource
    {
        protected readonly string objName;
        protected readonly string propName;

        protected BaseTestDataSourceAttribute(bool friendlyName, string objName, string propName, Type type)
        {
            if (!type.GetInterfaces().Any(i => i == typeof(ISyntaxSource))) throw new Exception($"{type} is not ISyntaxSource");
            this.friendlyName = friendlyName;
            this.objName = objName;
            this.propName = propName;
            SourceType = type;
        }

        protected readonly bool friendlyName;

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var getnameDelegate = friendlyName ? GetFriendlyTypeNameDelegate : GetCompleteTypeNameDelegate;
            var (comparerSyntax, atts) = GetComparerDetail();
            var enumNonClass = GetTypes();
            foreach (var (type, comparer, diag) in enumNonClass.Select(d => InitialSourceClassInfo(d, comparerSyntax)))
            {
                yield return new object[] { GetSourceObj(getnameDelegate, atts, type), comparer, diag };
            }
        }

        protected  ISyntaxSource CreateSyntaxSource(string name, params SourceProperty[] props)
        {
            return (ISyntaxSource)Activator.CreateInstance(SourceType, name, props );
        }

        protected string InternalSourceType => SourceType.Name;

        public Type SourceType { get; }

        protected ISyntaxSource GetSourceObj(GetNameDelegate getnameDelegate, string[] atts, Type type)
        {
            return CreateSyntaxSource(objName, GetSourceProp(getnameDelegate(type), atts));
        }

        protected virtual SourceProperty[] GetSourceProp(string typeName, string[] atts)
        {
            return new[] { new SourceProperty(typeName, propName, atts) };
        }

        protected abstract (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax);

        protected abstract (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail();

        protected abstract IEnumerable<Type> GetTypes();

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            var diag = data[2] is null ? "none" : ((TypeInfo<IPropertySymbol>)data[2])(null).title;
            return $"{InternalSourceType}: {data[0]}\nComparer: {data[1]}\nDiagnostic: {diag}";
        }
    }
}