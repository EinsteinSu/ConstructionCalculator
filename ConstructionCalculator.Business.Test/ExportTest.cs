using System;
using System.Collections.Generic;
using System.IO;
using ConstructionCalculator.Business.Utilities;
using ConstructionCalculator.DataAccess;
using ConstructionCalculator.DataAccess.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class ExportTest : TestBase
    {
        private const string Folder = "D:\\Test";

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            if (Directory.Exists(Folder)) Directory.Delete(Folder, true);
        }

        [TestInitialize]
        public void Init()
        {
            if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
        }

        [TestMethod]
        public void ExportBusinessValue()
        {
            var items = new List<BusinessValue>
            {
                new BusinessValue {Id = 1, Name = "A"},
                new BusinessValue {Id = 2, Name = "B"}
            };
            TestExport("ExportBusinessValue", items, excel =>
             {
                 Assert.AreEqual("业态编号", GetValueFromExcelCell(excel, 1, 1));
                 Assert.AreEqual("A", GetValueFromExcelCell(excel, 2, 2));
             });
        }

        [TestMethod]
        public void ExportBusinessFeature()
        {
            var list = new List<BusinessFeature>
            {
                new BusinessFeature {Id = 1, Name = "A"},
                new BusinessFeature {Id = 2, Name = "B"},
            };
            TestExport("ExportBusinessFeature", list, excel =>
             {
                 Assert.AreEqual("业态特征编号", GetValueFromExcelCell(excel, 1, 1));
                 Assert.AreEqual("A", GetValueFromExcelCell(excel, 2, 2));
             });
        }

        [TestMethod]
        public void ExportCellMapping()
        {
            var list = new List<CellMapping>
            {
                new CellMapping {Id = 1, ColumnExcelNumber = "A"},
                new CellMapping {Id = 2, ColumnExcelNumber = "B"},
            };
            TestExport("ExportCellMapping", list, excel =>
            {
                Assert.AreEqual("列序号", GetValueFromExcelCell(excel, 1, 1));
                Assert.AreEqual("A", GetValueFromExcelCell(excel, 2, 2));
            });
        }

        [TestMethod]
        public void ExportConstructionValue()
        {
            var list = new List<ConstructionValue>
            {
                new ConstructionValue {Id = 1, Name = "A", DesignRequirement = ConstructionDesignRequirement.一级},
                new ConstructionValue {Id = 2, Name = "B",DesignRequirement = ConstructionDesignRequirement.二级},
            };
            TestExport("ExportConstructionValue", list, excel =>
            {
                Assert.AreEqual("名称", GetValueFromExcelCell(excel, 1, 1));
                Assert.AreEqual("一级", GetValueFromExcelCell(excel, 2, 2));
            });
        }

        [TestMethod]
        public void ExportConstruction()
        {
            var list = new List<Construction>
            {
                new Construction {Id = 1, Jzmc = "A"},
                new Construction {Id = 2, Jzmc = "B"},
            };
            TestExport("ExportConstruction", list, excel =>
            {
                Assert.AreEqual("建筑名称", GetValueFromExcelCell(excel, 1, 1));
                Assert.AreEqual("A", GetValueFromExcelCell(excel, 2, 1));
            });
        }

        [TestMethod]
        public void ExportRishLevel()
        {
            var list = new List<RiskLevel>
            {
                new RiskLevel {Id = 1, MinValue = 1.2},
                new RiskLevel {Id = 2, MinValue = 2.1},
            };
            TestExport("ExportConstructionValue", list, excel =>
            {
                Assert.AreEqual("最小值", GetValueFromExcelCell(excel, 1, 1));
                Assert.AreEqual("1.2", GetValueFromExcelCell(excel, 2, 1));
            });
        }

        private void TestExport<T>(string name, List<T> data, Action<ExcelPackage> validate) where T : IExport
        {
            var fileName = Path.Combine(Folder, $"{name}.xlsx");
            data.Export(fileName, "A Test");
            using (var excel = new ExcelPackage(new FileInfo(fileName)))
            {
                validate?.Invoke(excel);
            }
        }

        private string GetValueFromExcelCell(ExcelPackage excel, int rowIndex, int columnIndex)
        {
            var sheet = excel.Workbook.Worksheets[1];
            var cell = sheet.Cells[rowIndex, columnIndex];
            return cell.Text;
        }
    }
}