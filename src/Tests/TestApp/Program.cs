using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.IO;
using VisualizeIt;
using System.Runtime.Intrinsics.Arm;
using System.Diagnostics;
using System.Linq;
using System;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IResultWriter resultWriter = new FileWriter();
            IInputReader inputReader = new FileInputReader();
            PumlGenerator generator = new PumlGenerator();

            var inputStr = inputReader.Read();
            var resultStr = generator.Generate(inputStr);
            resultWriter.Write(resultStr);

            System.Console.Write(resultStr);
        }
    }
}