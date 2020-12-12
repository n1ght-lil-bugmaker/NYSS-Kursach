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
            enc.Data = "�������";
            enc.Key = "�����";

            Assert.AreEqual("�������", enc.Encode());

        }

        [TestMethod]
        public void ManyWordsEncode()
        {
            var enc = new Encoding();
            enc.Data = "����� ��� ������� �������� ������ �������";
            enc.Key = "�����������";

            Assert.AreEqual("����� ��� ������� �������� ������ �������", enc.Encode());
        }

        [TestMethod]
        public void StringWithNonAlphabeticSymbolsEncode()
        {
            var enc = new Encoding();
            enc.Data = "��� �������� ������������� �������?...���������)))000)) [laugh]";
            enc.Key = "�������������";

            Assert.AreEqual("��� �������� ������������� �������?...���������)))000)) [laugh]", enc.Encode());
        }
    }
}
