using System.Linq;

namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyFloatingPointEquality : PropertyDefaultEquality
    {
        public int Precision { get; internal set; }

        public override string EqualityString()
        {
            return $"&& (System.Math.Abs({Name} - other.{Name}) < System.Math.Pow(10,{-Precision}))";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add(System.Math.Round(this.{Name} * System.Math.Pow(10,{Precision}), 0).GetHashCode())";
        }
    }
}
