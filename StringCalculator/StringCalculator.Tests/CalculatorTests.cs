using NUnit.Framework;

namespace StringCalculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add__EmptyStringSupplied_ReturnsZero()
        {
            Assert.That(_calculator.Add(""), Is.EqualTo(0));
        }

        [Test]
        public void Add__WhitespaceStringSupplied_ReturnsZero()
        {
            Assert.That(_calculator.Add(" "), Is.EqualTo(0));
        }

        [TestCase("1", 1)]
        [TestCase("1, 2", 3)]
        [TestCase("1, 2 ,5", 8)]
        [TestCase("1, 2 ,5 ,1", 9)]
        [TestCase("1, 2, 5, 1, 11", 20)]
        public void Add_NumbersSupplied_SumOfNumbersEqualsExpected(string numbers, int expectedSum)
        {
            Assert.That(_calculator.Add(numbers), Is.EqualTo(expectedSum));
        }

        [Test]
        public void Add_NewLineDelimiter_ReturnsSix()
        {
            Assert.That(_calculator.Add("1\n2, 3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_ChangingDelimiter_ReturnsThree()
        {
            Assert.That(_calculator.Add("//;\n1;2"), Is.EqualTo(3));
        }

        [TestCase("-1", "Negatives not allowed: -1")]
        [TestCase("-1, -2, -3", "Negatives not allowed: -1, -2, -3")]
        public void Add_NegativeNumbersSupplied_ThrowsExceptionWithMessageContainingNumbers(string numbers, string expectedExceptionMessage)
        {
            Assert.That(() => _calculator.Add(numbers), Throws.Exception.With.Message.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void Add_NumberLargerThan1000Supplied_NumberIgnoredWhenAdding()
        {
            Assert.That(_calculator.Add("2, 1001"), Is.EqualTo(2));
        }

        [Test]
        public void Add_DelimiterOfAnyLength_ReturnsSix()
        {
            Assert.That(_calculator.Add("//[***]\n1***2***3"), Is.EqualTo(6));
        }

        [Test]
        public void Add_MultipleDelimiters_ReturnsSix()
        {
            Assert.That(_calculator.Add("//[*][%]\n1*2%3"), Is.EqualTo(6));
        }

        [TearDown]
        public void Teardown()
        {
            _calculator = null;
        }
    }
}
