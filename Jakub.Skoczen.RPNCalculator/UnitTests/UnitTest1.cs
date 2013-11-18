using System;
using NUnit.Framework;
using Jakub.Skoczen.RPNCalculator;

namespace UnitTests
{
    [TestFixture]
     class UnitTests
    {
        [Test]
        public void AddInts()
        {
            StackElement e1 = new StackElement("15");
            StackElement e2 = new StackElement("15");
            StackElement resEl=e1+e2;
            Assert.AreEqual("30", resEl.Value);
        }

        [Test]
        public void AddDoubles()
        {
            StackElement e1 = new StackElement("15,5677799");
            StackElement e2 = new StackElement("14,4322201");
            StackElement resEl = e1 + e2;
            Assert.AreEqual("30", resEl.Value);
        }

        [Test]
        public void AddIntAndDouble()
        {
            StackElement e1 = new StackElement("15");
            StackElement e2 = new StackElement("12,567");
            StackElement resEl = e1 + e2;
            Assert.AreEqual("27,567", resEl.Value);
        }

        [Test]
        public void SubInts()
        {
            StackElement e1 = new StackElement("100");
            StackElement e2 = new StackElement("25");
            StackElement resEl = e1 - e2;
            Assert.AreEqual("75", resEl.Value);
        }

        [Test]
        public void SubDoubles()
        {
            StackElement e1 = new StackElement("99,15454");
            StackElement e2 = new StackElement("9,154541");
            StackElement resEl = e1 - e2;
            Assert.AreEqual("89,999999", resEl.Value);
        }

        [Test]
        public void SubIntFromDouble()
        {
            StackElement e1 = new StackElement("99,15");
            StackElement e2 = new StackElement("9");
            StackElement resEl = e1 - e2;
            Assert.AreEqual("90,15", resEl.Value);
        }

        [Test]
        public void SubDoubleFromInt()
        {
            StackElement e1 = new StackElement("100");
            StackElement e2 = new StackElement("25,55");
            StackElement resEl = e1 - e2;
            Assert.AreEqual("74,45", resEl.Value);
        }

        [Test]
        public void MulInts()
        {
            StackElement e1 = new StackElement("10");
            StackElement e2 = new StackElement("5");
            StackElement resEl = e1 * e2;
            Assert.AreEqual("50", resEl.Value);
        }

        [Test]
        public void MulDoubles()
        {
            StackElement e1 = new StackElement("2,25");
            StackElement e2 = new StackElement("2,26");
            StackElement resEl = e1 * e2;
            Assert.AreEqual("5,085", resEl.Value);
        }

        [Test]
        public void DivInts()
        {
            StackElement e1 = new StackElement("100");
            StackElement e2 = new StackElement("4");
            StackElement resEl = e1 / e2;
            Assert.AreEqual("25", resEl.Value);
        }

        [Test]
        public void DivDoubles()
        {
            StackElement e1 = new StackElement("12,25");
            StackElement e2 = new StackElement("0,5");
            StackElement resEl = e1 / e2;
            Assert.AreEqual("24,5", resEl.Value);
        }

     










    }
}
