﻿using EMDD.KtEquatable.Core.Attributes;

using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static EMDD.KtEquatable.Core.DiagnosticData;
using static KtEquatable.Unit.Tests.TestGeneratorHelper;
using static KtEquatable.Unit.Tests.TestGeneratorHelper.SourceClass;
using static KtEquatable.Unit.Tests.TestSyntaxHelper;

namespace KtEquatable.Unit.Tests.Classes.TestDataSourceAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class EnumerableIgnoredDataSourceAttribute : BaseTestDataSourceAttribute
    {
        public EnumerableOrderType OrderType { get; }
        protected readonly bool isClass;

        public EnumerableIgnoredDataSourceAttribute(EnumerableOrderType orderType, bool friendlyName, string className, string propName, bool isClass) : base(friendlyName, className, propName)
        {
            OrderType = orderType;
            this.isClass = isClass;
        }

        protected override (Type type, string comparer, TypeInfo<IPropertySymbol> diag) InitialSourceClassInfo(Type type, ComparerSyntax comparerSyntax)
        {
            return (type, comparerSyntax(type), OtherAttributesIgnored);
        }

        protected override (ComparerSyntax comparerSyntax, string[] attributes) GetComparerDetail()
        {
            return OrderType switch
            {
                EnumerableOrderType.Ordered => (OrderedComparerSyntax(false, null),
                new[] { EnumerableOrderedAttr, IgnoreAttr }),
                EnumerableOrderType.Set => (SetComparerSyntax(false, null),
                new[] { EnumerableSetAttr, IgnoreAttr }),
                _ => (UnorderedComparerSyntax(false, null),
                new[] { EnumerableUnorderedAttr, IgnoreAttr }),
            };
        }

        protected override SourceClass GetSourceClass(GetNameDelegate getnameDelegate, string[] atts, Type type)
        {
            var otherProp = new SourceProperty("int", "OtherProp2", null);
            var ignoredProp = new SourceProperty(getnameDelegate(type), propName, atts);
            return new SourceClass(className, otherProp, ignoredProp);
        }

        protected override IEnumerable<Type> GetTypes()
        {
            if (isClass)
            {
                return BasicClassTypes().Select(ListOfEnumerables).SelectMany(f => f);
            }
            else
            {
                return ListOfAllNonClass().Select(ListOfEnumerables).SelectMany(f => f);
            }
        }
    }
}