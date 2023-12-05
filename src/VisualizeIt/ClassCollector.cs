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
        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            var tree = new RootNode()
            {
                Name = node.Identifier.ValueText,
                Modifier = node.Modifiers.First().ValueText,
            };
            trees.Add(tree);
            base.VisitClassDeclaration(node);
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
