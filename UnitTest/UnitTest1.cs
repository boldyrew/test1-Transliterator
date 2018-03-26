using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transliterator;
using System.Text;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public Transliterator.Transliterator tl;

        [TestMethod]
        public void Input1()
        {
            tl = new Transliterator.Transliterator();
            string inp = "Андрій";
            string expected = "Andrii";
            
            string actual = tl.GetTransliteratedWord(inp);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Input2()
        {
            tl = new Transliterator.Transliterator();
            string inp = "Чернівці";
            string expected = "Chernivtsi";

            string actual = tl.GetTransliteratedWord(inp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input3()
        {
            tl = new Transliterator.Transliterator();
            string inp = "Корюківка";
            string expected = "Koriukivka";

            string actual = tl.GetTransliteratedWord(inp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input4()
        {
            tl = new Transliterator.Transliterator();
            string inp = "Згорани";
            string expected = "Згорани";

            string actual = tl.GetTransliteratedWord(inp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input5()
        {
            tl = new Transliterator.Transliterator();
            string inp = "";
            string expected = "";

            string actual = tl.GetTransliteratedWord(inp);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Input6()
        {
            tl = new Transliterator.Transliterator();
            string inp = "#Яготин-Яготин";
            string expected = "#Iahotyn-Yahotyn";

            string actual = tl.GetTransliteratedWord(inp);
            Assert.AreEqual(expected, actual);
        }
    }
}
