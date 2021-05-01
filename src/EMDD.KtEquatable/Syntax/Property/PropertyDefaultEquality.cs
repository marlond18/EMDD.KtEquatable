using System.Linq;

namespace EMDD.KtSourceGen.KtEquatable.Syntax.Property
{
    public class PropertyDefaultEquality : PropertyEqualityBase
    {
        public virtual string EqualityString()
        {
            return $"&& global::System.Collections.Generic.EqualityComparer<{Type}>.Default.Equals({Name}!, other.{ Name}!)";
        }

        public virtual string HashCodeString()
        {
            return $"hashCode.Add(this.{Name}!, global::System.Collections.Generic.EqualityComparer<{Type}>.Default)";
        }

        public string Name { get; internal set; }

        public string Type { get; internal set; }
    }
}