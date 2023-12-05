using VisualizeIt;

namespace VisualizeItTests
{
    public class OneClassGenerationTests
    {
        [Fact]
        public void EmptyClassTest()
        {
            string input = Path.Combine("input", "EmptyClass.cs");
            string check = Path.Combine("input", "EmptyClass.puml");
            PumlGenerator gen = new PumlGenerator();

            var inputStr = File.ReadAllText(input);
            var resultStr = gen.Generate(inputStr);

            var checkStr = File.ReadAllText(check);
            Assert.Equal(checkStr, resultStr);
        }
    }
}