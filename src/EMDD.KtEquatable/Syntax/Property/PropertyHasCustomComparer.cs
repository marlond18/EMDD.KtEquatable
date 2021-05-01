using System.Linq;

using static EMDD.KtSourceGen.KtEquatable.Core.CoreHelpers;

namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public abstract class PropertyHasCustomComparer : PropertyDefaultEquality
    {
        public abstract string ComparerName { get; }

        public abstract string Code { get; }

        public override string EqualityString()
        {
            return $"&& global::{NameSpace}.Core.{ComparerName}<{Type}>.Default.Equals({Name}!, other.{Name}!)";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add(this.{Name}!, global::{NameSpace}.Core.{ComparerName}<{Type}>.Default)";
        }
        public static string EqualityComparerText() => $@"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace {NameSpace}.Core
{{
{string.Join("\n",(new PropertyHasCustomComparer[] {
        new PropertyUnorderedCollectionEquality(),
        new PropertySetEquality(),
        new PropertyReferenceEquality(),
        new PropertyOrderedCollectionEquality(),
        new PropertyDictionaryEquality(),
        }).Select(p=>p.Code)) }
}}";
    }
}