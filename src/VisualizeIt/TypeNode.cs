namespace VisualizeIt
{
    public class TypeNode
    {
        public string Name { get; set; }
        public string? Parent { get; set; }
        public NodeType Type { get; set; }
        public List<string> Declaration { get; set; } = new ();
    }
}
