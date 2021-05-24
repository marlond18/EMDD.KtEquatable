
using System.Linq;

namespace KtEquatable.Unit.Tests.Assertions
{
    public interface ISyntaxSource
    {
        SourceProperty[] Props { get; }
        string InternalType { get; }
        string ObjectName { get; }
        string ImplementationOnGenCode { get; }
    }

    public readonly struct SourceClass : ISyntaxSource
    {
        public string ObjectName { get; }
        public SourceProperty[] Props { get; }
        public string InternalType => "class";

        public SourceClass(string name, params SourceProperty[] props)
        {
            ObjectName = name;
            Props = props;
        }

        public override string ToString()
        {
            return $"{InternalType} {{Name: {ObjectName}\n\t- {string.Join("\n\t- ", Props.Select(p => p.ToString()))}}}";
        }

        public string ImplementationOnGenCode => $" : IEquatable<{ObjectName}>";
    }

    public readonly struct SourceRecord : ISyntaxSource
    {
        public string ObjectName { get; }
        public SourceProperty[] Props { get; }

        public string InternalType => "record";

        public string ImplementationOnGenCode => "";

        public SourceRecord(string name, params SourceProperty[] props)
        {
            ObjectName = name;
            Props = props;
        }

        public override string ToString()
        {
            return $"{InternalType} {{Name: {ObjectName}\n\t- {string.Join("\n\t- ", Props.Select(p => p.ToString()))}}}";
        }
    }

    public readonly struct SourceProperty
    {
        private readonly string typeName;
        private readonly string propName;
        private readonly string[] attributes;

        public SourceProperty(string typeName, string propName, params string[] attributes)
        {
            this.typeName = typeName;
            this.propName = propName;
            this.attributes = attributes;
        }
        public string PropToString()
        {
            var attsString = attributes is null || attributes.Length == 0 ? "" : $"\t\t{string.Join($"{System.Environment.NewLine}\t\t", attributes.Select(a => $"[{a}]"))}\n";
            return $"{attsString}\t\t{typeName} {propName} {{ get; set; }}";
        }
        public override string ToString()
        {
            var attsString = attributes is null || attributes.Length == 0 ? "" : $", attr: {string.Join(",", attributes)}";
            return $"Property {{type: {typeName}, name: {propName}{attsString}";
        }
    }
}