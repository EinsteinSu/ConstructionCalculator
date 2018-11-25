using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class ImportsTest : TestBase
    {
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
            });
        }

        [TestMethod]
        public void Construction()
        {
            BusinessValue();
            BusinessFeatureImport();
            ConstructionValue();
            ImportAndValidate("Construction.xlsx", stream =>
            {
                var importer = new ConstructionImport(stream);
                importer.Import();
                var data = Context.Constructions.First();
                Assert.AreEqual(1, data.ConstructionValueId);
                Assert.AreEqual(201, data.BusinessFeatureId);
                Assert.AreEqual(7, data.Ds);
                //todo fix all asserts
                Assert.AreEqual(importer.RowCount, 4);
                Assert.AreEqual(Context.Constructions.Count(), 3);
            });
        }

        [TestMethod]
        public void BusinessValue()
        {
            ImportAndValidate("BusinessValue.xlsx", stream =>
            {
                var importer = new BusinessValueImport(stream);
                importer.Import();
                var data = Context.BusinessValues.First();
                Assert.AreEqual(1, data.Id);
                Assert.AreEqual("车库", data.Name);
                Assert.AreEqual(importer.RowCount, 29);
                Assert.AreEqual(Context.BusinessValues.Count(), 28);
            });
        }

        [TestMethod]
        public void BusinessFeature()
        {
            BusinessValue();
            BusinessFeatureImport();
        }

        public void BusinessFeatureImport()
        {
            ImportAndValidate("BusinessFeature.xlsx", stream =>
            {
                var importer = new BusinesFeatureImport(stream);
                importer.Import();
                var data = Context.BusinessFeatures.First();
                Assert.AreEqual(101, data.Id);
                Assert.AreEqual("室内停车场", data.Name);
                Assert.AreEqual(1, data.BusinessValueId);
                Assert.AreEqual(0.2, data.Hdyza);
                Assert.AreEqual(importer.RowCount, 60);
                Assert.AreEqual(Context.BusinessFeatures.Count(), 59);
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
                Assert.AreEqual(importer.RowCount, 7);
                Assert.AreEqual(Context.ConstructionValues.Count(), 7);
            });
        }

        [TestMethod]
        public void RiskLevel()
        {
            ImportAndValidate("RiskLevel.xlsx", stream =>
            {
                var importer = new RiskLevelImport(stream);
                importer.Import();
                var data = Context.RiskLevels.First();
                Assert.AreEqual(data.MinValue, 0);
                Assert.AreEqual(data.MaxValue, 1);
                Assert.AreEqual(data.Color, "White");
                Assert.AreEqual(data.Description, "安全");
            });
        }
    }
}