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
        private readonly PumlTranslation pumlTranslation;

        public ClassCollector(PumlTranslation pumlTranslation)
        {
            this.pumlTranslation = pumlTranslation;
        }

        public List<TypeFrame> Frames { get; set; } = new();
        public List<TypeNode> TypeNodes { get; set; } = new();

        public List<string> GetClasses()
        {
            var classes = TypeNodes.Where(t => t.Type == NodeType.Class);
            return classes.Select(f =>
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(f.Declaration[0] + f.Declaration.Skip(1).Aggregate((a, b) => a + " " + b));
                
                var body = TypeNodes.Where(n => n.Parent is not null && n.Parent.Equals(f.Name))
                    .Select(f =>
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine(AddIndent() + f.Declaration[0] + f.Declaration.Skip(1).Aggregate((a, b) => a + " " + b));
                        return sb.ToString();
                    })
                    .Aggregate((a, b) => a + b);

                sb.AppendLine("{");
                sb.Append(body);
                sb.Append("}");
                return sb.ToString();
            }).ToList();
        }

        private string AddIndent()
        {
            return "  ";
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            TypeNode typeNode = new();
            typeNode.Name = node.Identifier.ToString();
            typeNode.Type = NodeType.Class;
            var modifiersStr = string.Join(" ", node.Modifiers.Select(m => pumlTranslation.Modifier(m.ToString())).OfType<string>());
            typeNode.Declaration.Add(modifiersStr);
            typeNode.Declaration.Add(node.Keyword.ToString());
            typeNode.Declaration.Add(node.Identifier.ToString());
            TypeNodes.Add(typeNode);

            base.VisitClassDeclaration(node);
        }

        public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
        {
            var typenode = new TypeNode();
            typenode.Type = NodeType.Field;
            var parentNode = (node.Parent as ClassDeclarationSyntax);
            typenode.Parent = parentNode?.Identifier.ToString();
            var modifiersStr = string.Join(" ", node.Modifiers.Select(m => pumlTranslation.Modifier(m.ToString())).OfType<string>());
            typenode.Declaration.Add(modifiersStr);
            var type = node.Declaration.Type as PredefinedTypeSyntax;
            typenode.Declaration.Add(type.Keyword.ToString());
            var variable = node.Declaration.Variables.First();
            typenode.Declaration.Add(variable.Identifier.ToString());
            TypeNodes.Add(typenode);

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
