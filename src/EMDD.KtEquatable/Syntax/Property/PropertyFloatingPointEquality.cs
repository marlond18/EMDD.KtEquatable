using System.Collections.Generic;
using System.Linq;

using EMDD.KtEquatable.Core;

namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyFloatingPointEquality : PropertyDefaultEquality
    {
        public int Precision { get; internal set; }

        public override string EqualityString()
        {
            return $"&& {Name}.NearEquals(other.{Name}, {Precision})";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add({Name}.GetDoubleHashCode({Precision}))";
        }
    }

    public class DoubleEnumerableEquality : PropertyDefaultEquality
    {
        public int Precision { get; internal set; }

        public bool InOrder { get; internal set; }

        public bool IsSet { get; internal set; }

        public override string EqualityString()
        {
            if(IsSet) return $"&& {Name}.SetNearEquals(other.{Name}, {Precision})";
            if (InOrder)
            {
                return $"&& {Name}.SequenceNearEquals(other.{Name}, {Precision})";
            }
            else
            {
                return $"&& {Name}.ContentNearEquals(other.{Name}, {Precision})";
            }
        }

        public override string HashCodeString()
        {
            if (IsSet) return "hashCode.Add(0)";
            if (InOrder)
            {
                return $"hashCode.Add({Name}.GetSequenceDoubleHashCode({Precision}))";
            }
            else
            {
                return $"hashCode.Add({Name}.GetContentDoubleHashCode({Precision}))";
            }
        }
    }
}