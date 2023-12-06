using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizeIt
{
    public class ClassCollector : CSharpSyntaxWalker
    {
        List<RootNode> trees = new List<RootNode>();
        public List<RootNode> SourceTree { get => trees; }
        public StringBuilder sb = new StringBuilder();
        public List<TypeFrame> ClassFrames { get; set; } = new List<TypeFrame>();
        public string GetResult()
        {
            return ClassFrames.Select(f =>
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(f.Header.Aggregate((a, b) => a + " " + b));
                sb.AppendLine("{");
                if (f.Body.Any())
                {
                    // fill the body
                }
                sb.AppendLine("}");
                return sb.ToString();
            }).Aggregate((a, b) => a + b);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            TypeFrame frame = new();

            string modifiersStr = node.Modifiers.Select(m => m.ToString()).Aggregate((a, b) => (a + b));
            frame.Header.Add(modifiersStr);
            frame.Header.Add(node.Keyword.ToString());
            frame.Header.Add(node.Identifier.ToString());
            if (node.ChildNodes().Any())
            {
                // Childs
                // frame.Body.Add("");
                base.VisitClassDeclaration(node);
            }

            ClassFrames.Add(frame);
        }

        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            //node.Declaration
            //    //.OfType<VariableDeclarationSyntax>()
            //    //.Where(e => e.Kind() == SyntaxKind.VariableDeclaration)
            //    .Select(e => new Node()
            //{
            //    Name = 
            //    Modifier = e
            //    };
            //trees.Add(tree);

            base.VisitFieldDeclaration(node);
        }
    }

    public class TypeFrame
    {
        public List<string> Header { get; set; } = new List<string>();
        public List<string> Body { get; set; } = new List<string>();
    }

    public class Node
    {
        public string Name { get; set; }
        public string Type { get; internal set; }
        public string Modifier { get; internal set; }
    }

    public class RootNode
    {
        public List<Node> Nodes = new List<Node>();

        public string Name { get; internal set; }
        public string Modifier { get; internal set; }
    }
}
