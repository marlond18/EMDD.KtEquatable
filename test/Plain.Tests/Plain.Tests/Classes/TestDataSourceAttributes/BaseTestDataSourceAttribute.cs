
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public abstract class BaseTestDataSourceAttribute : Attribute, ITestDataSource
    {
        protected readonly string className;
        protected readonly string propName;

        protected BaseTestDataSourceAttribute(bool friendlyName, string className, string propName)
        {
            FriendlyName = friendlyName;
            this.className = className;
            this.propName = propName;
        }

        public bool FriendlyName { get; }

        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            var getnameDelegate = FriendlyName ? GetFriendlyTypeNameDelegate : GetCompleteTypeNameDelegate;
            var (comparerSyntax, atts) = GetComparerDetail();
            var enumNonClass = GetTypes();
            foreach (var (type, comparer, diag) in enumNonClass.Select(d => InitialSourceClassInfo(d, comparerSyntax)))
            {
                yield return new object[] { GetSourceClass(getnameDelegate, atts, type), comparer, diag };
            }
        }

        protected virtual SourceClass GetSourceClass(GetNameDelegate getnameDelegate, string[] atts, Type type)
        {
            var sourceProp = new SourceProperty(getnameDelegate(type), propName, atts);
            return new SourceClass(className, sourceProp);
        }

        protected abstract (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax);

        protected abstract (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail();

        protected abstract IEnumerable<Type> GetTypes();

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            var diag = data[2] is null ? "none" : ((TypeInfo<IPropertySymbol>)data[2])(null).title;
            return $"SourceClass: {data[0]}\nComparer: {data[1]}\nDiagnostic: {diag}";
        }
    }
}