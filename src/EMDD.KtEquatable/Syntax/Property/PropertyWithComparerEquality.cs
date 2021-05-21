using EMDD.KtEquatable.Syntax.Property.Base;

namespace EMDD.KtEquatable.Syntax.Property
{
    public class PropertyWithComparerEquality : PropertyDefaultEquality
    {
        public string NewOfComparer { get; set; }

        public override string EqualityString()
        {
            return $"&& {NewOfComparer}.Equals({Name}!, other.{Name}!)";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add(this.{Name}!, {NewOfComparer})";
        }
    }
}