﻿using System;

namespace EMDD.KtEquatable.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EquatableAttribute : Attribute
    {
        ///// <summary>
        ///// These only affect abstract classes
        ///// <para/> If this is set to true, all autogenerated equality check and GetHashCode Method will be marked as abstract
        ///// <para/> Deriving classes marked with Equatable attribute will have the autogenerated overrides of the methods
        ///// </summary>
        //public bool EqualWillAlsoBeAbstract { get; set; }

        ///// <summary>
        ///// Add all properties (including derived) on the equality check
        ///// </summary>
        //public bool CheckAllProperties { get; set; }
    }
}