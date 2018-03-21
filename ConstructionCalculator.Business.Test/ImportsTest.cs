using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class ImportsTest
    {
        protected ConstructionDataContext Context = new ConstructionDataContext();
        private const string prefix = "ConstructionCalculator.Business.Test.TestResource.";
        [TestCleanup]
        public void Cleanup()
        {
            Context.Database.ExecuteSqlCommand("Delete From ConstructionValues");
            Context.Database.ExecuteSqlCommand("Delete From CellMappings");
            Context.Dispose();
        }

        void ImportAndValidate(string fileName, Action<Stream> validation)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream =
                assembly.GetManifestResourceStream(prefix + fileName)
            )
            {
                validation?.Invoke(stream);
            }
        }

        [TestMethod]
        public void CellMapping()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
                var data = Context.CellMappings.First();
                Assert.AreEqual(1, data.ColumnNumber);
                Assert.AreEqual("A", data.ColumnExcelNumber);
                Assert.AreEqual("建筑名称", data.ColumnName);
                Assert.IsTrue(importer.RowCount == 67);
                Assert.IsTrue(Context.CellMappings.Count() == 67);
            });

        }

        [TestMethod]
        public void Construction()
        {
            ImportAndValidate("Construction.xlsx", stream =>
            {
                var importer = new ConstructionImport(stream);
                importer.Import();
                var data = Context.Constructions.First();
                Assert.AreEqual(1, data.ConstructionValueId);
                Assert.AreEqual(2, data.BusinessValueId);
                Assert.AreEqual(1, data.BusinessFeatureId);
                Assert.AreEqual(7, data.Ds);
                //todo fix all asserts
                Assert.AreEqual(importer.RowCount, 308);
                Assert.AreEqual(Context.Constructions.Count(), 308);
            });
        }

        [TestMethod]
        public void ConstructionValue()
        {
            ImportAndValidate("ConstructionValue.xlsx", stream =>
            {
                var importer = new ConstructionValueImport(stream);
                importer.Import();
                var data = Context.ConstructionValues.First();
                Assert.AreEqual("钢筋混凝土", data.Name);
                Assert.AreEqual(1, data.Id);
                Assert.AreEqual(data.DesignRequirement, ConstructionDesignRequirement.一级);
                Assert.AreEqual(data.Jgkhyz, 2.37);
                Assert.AreEqual(importer.RowCount, 6);
                Assert.AreEqual(Context.ConstructionValues.Count(), 6);
            });
        }
    }
}
