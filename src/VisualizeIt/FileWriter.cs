using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizeIt
{
    public class FileWriter : IResultWriter
    {
        public void Write(string value)
        {
            var dirPath = Path.Combine(Directory.GetCurrentDirectory(), "output");
            Directory.CreateDirectory(dirPath);
            Write(value, dirPath);
        }

        private void Write(string resultStr, string dir, string fileName)
        {
            var filePath = Path.Combine(dir, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(resultStr);
            }
        }
        private void Write(string resultStr, string dir)
        {
            var name = "TestClass.puml";
            Write(resultStr, dir, name);
        }

    }
}
