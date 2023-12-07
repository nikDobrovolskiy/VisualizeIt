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
            ClassCollector collector = new ClassCollector(new PumlTranslation());
            SourceTreeConverter converter = new SourceTreeConverter();

            SyntaxNode node = SyntaxFactory.ParseCompilationUnit(input);
            collector.Visit(node);
            var classes = collector.GetClasses();
            var pumlstr = converter.ConvertToPuml(classes);
            return pumlstr;
        }
    }
}
