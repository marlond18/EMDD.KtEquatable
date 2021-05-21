
using System.CodeDom.Compiler;
using System.Collections.Generic;
namespace EMDD.KtEquatable.Core
{
    public static class SummaryGenerators
    {
        public static void AddSummary(this IndentedTextWriter writer, SummaryString summary)
        {
            writer.Write("/// <summary>");
            if (summary.Contents?.Count > 0)
            {
                foreach (var (content, newLine) in summary.Contents)
                {
                    writer.WriteLine();
                    writer.Write("///");
                    if (newLine) writer.Write("<para>");
                    writer.Write(content);
                    if (newLine) writer.Write("</para>");
                }
            }
            else
            {
                writer.WriteLine();
                writer.Write("/// Blank");
            }
            writer.WriteLine();
            writer.Write("/// </summary>");
            foreach (var param in summary.Params)
            {
                writer.WriteLine();
                writer.Write($@"/// <param name=""{param.Name}"">{param.Description}</param>");
            }
            if (summary.Returns is not null)
            {
                writer.WriteLine();
                writer.Write($"/// <returns>{summary.Returns}</returns>");
            }
            writer.WriteLine();
        }

        internal static SummaryString EqualOpSummary => new()
        {
            Contents = new List<(string content, bool newLine)>
            {
                ("Indicates whether the object on the left is equal to the object on the right.",false)
            },
            Params = new List<SummaryParam>
            {
                new SummaryParam{ Name="left", Description= "the left object"},
                new SummaryParam{ Name="right", Description= "the right object"}
            },
            Returns = "true if the objects are equal; otherwise, false."
        };

        internal static SummaryString NotEqualOpSummary => new()
        {
            Contents = new List<(string content, bool newLine)>
            {
                ("Indicates whether the object on the left is not equal to the object on the right.",false)
            },
            Params = new List<SummaryParam>
            {
                new SummaryParam{ Name="left", Description= "the left object"},
                new SummaryParam{ Name="right", Description= "the right object"}
            },
            Returns = "true if the objects are not equal; otherwise, false."
        };
    }
}