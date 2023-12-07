namespace VisualizeIt
{
    public class PumlTranslation
    {
        private readonly Dictionary<string, string> Modifiers = new Dictionary<string, string>();
        public PumlTranslation()
        {
            Modifiers.Add("public", "+");
            Modifiers.Add("internal", "~");
            Modifiers.Add("protected", "#");
            Modifiers.Add("private", "-");
        }
        internal string? Modifier(string input)
        {
            Modifiers.TryGetValue(input, out var modifier);
            if (modifier is null)
            {
                return null;
            }
            return modifier;
        }
    }
}
