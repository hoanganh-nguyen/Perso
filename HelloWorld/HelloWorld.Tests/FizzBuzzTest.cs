using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Tests
{
    [TestFixture]
    public class FizzBuzzTest
    {
        FizzBuzz _fizzBuzz;
        [SetUp]
        public void Init()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        public void TestGetFizzBuzz()
        {
            var tmp = _fizzBuzz.GetFizzBuzz(3);
            Assert.AreEqual("Fizz", tmp);
        }
    }
}
