using System.Text;

namespace VisualizeIt
{
    internal class SourceTreeConverter
    {
        public SourceTreeConverter()
        {
        }

        internal string ConvertToPuml(List<RootNode> sourceTree)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"@startuml Test");
            
            sourceTree.ForEach(x =>
            {
                sb.AppendLine($"class {x.Name}");
                sb.AppendLine("{");
                foreach (var node in x.Nodes)
                {
                    sb.AppendLine($"\t{node.Modifier} {node.Type} {node.Name}");
                }
                sb.AppendLine("}");
            });

            sb.Append("@enduml");
            return sb.ToString();
        }
    }
}