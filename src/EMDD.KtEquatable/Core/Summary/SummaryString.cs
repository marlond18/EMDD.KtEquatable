using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace EMDD.KtEquatable.Core
{
    public class SummaryString
    {
        public List<(string content, bool newLine)> Contents { get; set; } = new List<(string content, bool newLine)>();
        public List<SummaryParam> Params { get; set; } = new List<SummaryParam>();

        public string Returns { get; set; }
    }
}