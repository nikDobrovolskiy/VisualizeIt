namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = @"c:\\Work\Projects\github\VisualizeIt\src\Tests\TestApp\..input";
            string inputPath = Path.Combine(input, "SimpleClass.cs");
            System.Console.WriteLine(inputPath + " - " + File.Exists(inputPath));

        }
    }
}