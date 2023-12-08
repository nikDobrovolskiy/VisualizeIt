using System.Collections;
using VisualizeIt;

namespace VisualizeItTests
{
    public class ClassGenerationTests
    {
        [Theory]
        [ClassData(typeof(WrongInputTestData))]
        public void WrongInputData_ShouldReturnEmptyOutput(string inputStr)
        {
            // arrange
            PumlGenerator gen = new PumlGenerator();

            // act
            var resultStr = gen.Generate(inputStr);

            // assert
            Assert.True(string.IsNullOrEmpty(resultStr));
        }

        [Fact]
        public void ClassAccessModifiers_ShouldBeEqual()
        {
            // arrange
            PumlGenerator gen = new PumlGenerator();
            string input = Path.Combine("input", "ClassAccessModifiers.cs");
            string check = Path.Combine("input", "ClassAccessModifiers.puml");
            var inputStr = File.ReadAllText(input);

            // act
            var resultStr = gen.Generate(inputStr);

            // assert
            var checkStr = File.ReadAllText(check);
            Assert.Equal(checkStr, resultStr);
        }

        [Fact]
        public void FieldTypeKeywords_ShouldBeEqual()
        {
            // arrange
            PumlGenerator gen = new PumlGenerator();
            string input = Path.Combine("input", "FieldTypeKeywords.cs");
            string check = Path.Combine("input", "FieldTypeKeywords.puml");
            var inputStr = File.ReadAllText(input);

            // act
            var resultStr = gen.Generate(inputStr);

            // assert
            var checkStr = File.ReadAllText(check);
            Assert.Equal(checkStr, resultStr);
        }

        [Fact]
        public void SimpleClassTest()
        {
            // arrange
            PumlGenerator gen = new PumlGenerator();
            string input = Path.Combine("input", "SimpleClass.cs");
            string check = Path.Combine("input", "SimpleClass.puml");
            var inputStr = File.ReadAllText(input);

            // act
            var resultStr = gen.Generate(inputStr);

            // assert
            var checkStr = File.ReadAllText(check);
            Assert.Equal(checkStr, resultStr);
        }

        [Fact]
        public void ClassWithFieldTest()
        {
            // arrange
            PumlGenerator gen = new PumlGenerator();
            string input = Path.Combine("input", "ClassWithField.cs");
            string check = Path.Combine("input", "ClassWithField.puml");
            var inputStr = File.ReadAllText(input);

            // act
            var resultStr = gen.Generate(inputStr);

            // assert
            var checkStr = File.ReadAllText(check);
            Assert.Equal(checkStr, resultStr);
        }
    }

    class WrongInputTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { string.Empty };
            yield return new object[] { null };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}