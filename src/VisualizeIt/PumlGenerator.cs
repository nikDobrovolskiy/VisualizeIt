using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace VisualizeIt
{
    public class PumlGenerator
    {
        public string Generate(string input)
        {
            ClassCollector collector = new ClassCollector();
            SyntaxNode node = SyntaxFactory.ParseCompilationUnit(input);
            collector.Visit(node);
            

            SourceTreeConverter converter = new SourceTreeConverter();
            var pumlstr = converter.ConvertToPuml(collector.SourceTree);

            return pumlstr;
        }
    }
}
