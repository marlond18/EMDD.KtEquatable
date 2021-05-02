using System.Linq;

namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyFloatingPointEquality : PropertyDefaultEquality
    {
        public int Precision { get; internal set; }

        public override string EqualityString()
        {
            return $"&& (Math.Abs({Name} - other.{Name}) < Math.Pow(10,{-Precision}))";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add(Math.Round(this.{Name} * Math.Pow(10,{Precision}), 0).GetHashCode())";
        }
    }
}