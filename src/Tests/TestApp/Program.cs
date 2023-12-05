using System.IO;
using VisualizeIt;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Path.Combine("input", "SimpleClass.cs");
            var inputStr = File.ReadAllText(input);
            PumlGenerator gen = new PumlGenerator();
            var resultStr = gen.Generate(inputStr);
        }
    }
}