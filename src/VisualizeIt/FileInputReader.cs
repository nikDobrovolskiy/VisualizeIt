using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizeIt
{
    public class FileInputReader : IInputReader
    {
        public string Read()
        {
            string input = Path.Combine("input", "TestClass.cs");
            var inputStr = File.ReadAllText(input);
            return inputStr;
        }
    }
}
