using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.IO;
using VisualizeIt;
using System.Runtime.Intrinsics.Arm;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Path.Combine("input", "TestClass.cs");
            var inputStr = File.ReadAllText(input);         
            PumlGenerator gen = new PumlGenerator();
            var resultStr = gen.Generate(inputStr);

        }
    }
}