using EMDD.KtEquatable.Syntax.Property.Base;

namespace EMDD.KtEquatable.Syntax.Property
{
    public class PropertyDefaultEquality : PropertyEqualityBase
    {
        public virtual string EqualityString()
        {
            return $"&& EqualityComparer<{Type}>.Default.Equals({Name}!, other.{ Name}!)";
        }

        public virtual string HashCodeString()
        {
            return $"hashCode.Add(this.{Name}!, EqualityComparer<{Type}>.Default)";
        }

        public string Name { get; internal set; }

        public string Type { get; internal set; }
    }
}