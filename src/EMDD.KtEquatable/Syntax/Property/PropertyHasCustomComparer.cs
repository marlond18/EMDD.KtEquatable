namespace EMDD.KtEquatable.Syntax.Property
{
    public abstract class PropertyHasCustomComparer : PropertyDefaultEquality
    {
        public abstract string ComparerName { get; }

        public override string EqualityString()
        {
            return $"&& {ComparerName}<{Type}>.Default.Equals({Name}!, other.{Name}!)";
        }

        public override string HashCodeString()
        {
            return $"hashCode.Add(this.{Name}!, {ComparerName}<{Type}>.Default)";
        }
    }
}