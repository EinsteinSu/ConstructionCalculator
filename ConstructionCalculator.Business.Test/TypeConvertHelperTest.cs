using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class TypeConvertHelperTest
    {
        [TestMethod]
        public void ConvertColor()
        {
            const string color = "Red";
            var c = color.ConvertToColor();
            Assert.AreEqual(Color.Red, c);
        }
    }
}