using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMDD.KtEquatable.Core.Attributes;
namespace NugetPackageTester
{
    [Equatable]
    public partial class Class1
    {
        [ReferenceEquality]
        public string? MyProperty { get; set; }
    }
}
