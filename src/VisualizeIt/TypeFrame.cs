namespace VisualizeIt
{
    public class TypeFrame
    {
        public string Name { get; set; }
        public List<string> Declaration { get; set; } = new ();
        public List<TypeFrame> Body { get; set; } = new ();
    }
}
