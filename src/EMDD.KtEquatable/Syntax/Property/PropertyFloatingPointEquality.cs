namespace EMDD.KtEquatable.Syntax.Property
{
    public class PropertyFloatingPointEquality : PropertyDefaultEquality
    {
        public int Precision { get; internal set; }

        public override string EqualityString()
        {
            return $"new PropertyFloatingPointEquality({Precision}).Equals({Name}, other.{Name})";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add(this.{Name}!, new PropertyFloatingPointEquality({Precision}))";
        }
    }
}