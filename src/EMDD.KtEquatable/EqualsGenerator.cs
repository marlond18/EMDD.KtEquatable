using EMDD.KtEquatable.Core;

using Microsoft.CodeAnalysis;

using System.Diagnostics;

using static EMDD.KtEquatable.Core.CoreHelpers;
namespace EMDD.KtEquatable
{
    [Generator]
    public class EqualsGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            //#if DEBUG
            //            Debugger.Launch();
            //#endif
            context.RegisterForSyntaxNotifications(() => new EquatableReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxContextReceiver is EquatableReceiver reciever)
            {
                var aggregator = GeneratorWriter.Create(context);
                foreach (var (node, symbol) in reciever.OtherTypes)
                {
                    context.ReportDiagnostic(DiagnosticData.Create(DiagnosticData.TypeNotSupported, symbol, node));
                }
                foreach (var (node, symbol) in reciever.ClassTypes)
                {
                    aggregator.AddClassSourceText(node,symbol);
                }
                foreach (var (node, symbol) in reciever.RecordTypes)
                {
                    aggregator.AddRecordSourceText(node,symbol);
                }
                foreach(var (node, symbol) in reciever.StructTypes)
                {
                    aggregator.AddRecordSourceText(node,symbol);
                }
                foreach (var diag in aggregator.Diagnostics)
                {
                    context.ReportDiagnostic(diag);
                }
                foreach (var (className, text) in aggregator.SourceTexts)
                {
                    context.AddSource($"{className.ReplaceEscapeChars()}.{SourceGenName}.g.cs"!, text);
                }
            }
        }
    }
}
