using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication3.Models;

namespace Tests
{
    [TestClass]
    public class DecodeTests
    {
        [TestMethod]
        public void OneWordDecode()
        {
            var enc = new Encoding();
            enc.Data = "ььдэю";
            enc.Key = "питон";

            Assert.AreEqual("мусор", enc.Decode());
        }

        [TestMethod]
        public void ManyWordsDecode()
        {
            var enc = new Encoding();
            enc.Data = "Еэбжщк жшч вэыюъч шяошыэи ымьхёмжюудо";
            enc.Key = "усталь";

            Assert.AreEqual("Сложно уже всякие шутейки придумывать",
                            enc.Decode());
        }

        [TestMethod]
        public void StringWithNonAlphabeticSymbolsDecode()
        {
            var enc = new Encoding();
            enc.Data = "Мняи о ютешею ы ёвче бтса ёъянкьь пюббфф! PROFIT!";
            enc.Key = "антипитон";

            Assert.AreEqual("Мама я хацкер и этот тест успешно прошел! PROFIT!",
                            enc.Decode());
        }
    }
}
