using System;
using NUnit.Framework;
using TDD;

namespace TDDTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void AddNull_Throws()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<ArgumentNullException>(() => calculator.Add(null));
        }

        [Test]
        public void AddEmpty_Zero()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add(string.Empty), 0);
        }

        [Test]
        public void AddOne_One()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1"), 1);
        }

        [Test]
        public void AddTwo_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1,2"), 3);
        }

        [Test]
        public void AddFive_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1,2,3,4,5"), 15);
        }

        [Test]
        public void AddSeven_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1,5,3,4,5,2,19"), 39);
        }

        [Test]
        public void AddWithLines_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1\n2,3"), 6);
        }

        [Test]
        public void AddWithMultipleLines_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1\n2,7\n2,3"), 15);
        }

        [Test]
        public void AddWithSemicolon_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("//;\n1;2"), 3);
        }

        [Test]
        public void AddWithNegatives_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Add("-3,-1,2,3"), "negatives not allowed - -3 -1");
        }

        [Test]
        public void AddWithVeryBigNegativeNumbers_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Add("1,-19000000000000000000"), "negatives not allowed - -19000000000000000000");
        }

        [Test]
        public void AddWithVeryBigNumbers_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1,5,2,900,19000000000000000000"), 908);
        }

        [Test]
        public void AddWithNumberBiggerThan1000_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("1,5,2,2900"), 8);
        } 

        [Test]
        public void AddWithLongDelimiter_Summ()
        {
            Calculator calculator = new Calculator();
            Assert.AreEqual(calculator.Add("//[***]\n1***2***3"), 6);
        }
    }
}
