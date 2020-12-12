using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Models;

namespace Tests
{
    [TestClass]
    public class EncodeTests
    {
        [TestMethod]
        public void OneWordEncode()
        {
            var enc = new Encoding();
            enc.Data = "собачка";
            enc.Key = "котик";

            Assert.AreEqual("ьэуивхо", enc.Encode());

        }

        [TestMethod]
        public void ManyWordsEncode()
        {
            var enc = new Encoding();
            enc.Data = "Лично мне собачки нравятся больше котиков";
            enc.Key = "лабрадорчик";

            Assert.AreEqual("Чишюо рьх ичллчлщ нфотцыьк бпьььу ыёыуцог", enc.Encode());
        }

        [TestMethod]
        public void StringWithNonAlphabeticSymbolsEncode()
        {
            var enc = new Encoding();
            enc.Data = "Как называют неаккуратного раввина?...Головорез)))000)) [laugh]";
            enc.Key = "шуткизатриста";

            Assert.AreEqual("Гуэ шипыфржд аешюэющзтаяла гаъхыши?...Коюякагеа)))000)) [laugh]", enc.Encode());
        }
    }
}
