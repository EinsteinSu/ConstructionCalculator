using System;
using System.Linq;
using ConstructionCalculator.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class ConstructionFormulaTest
    {
        protected ConstructionDataContext Context = new ConstructionDataContext();

        [TestMethod]
        public void ValueFeatchTest()
        {
            var cellMappings = Context.CellMappings.ToList();
          
            Console.WriteLine(cellMappings.Count);
        }
    }
}