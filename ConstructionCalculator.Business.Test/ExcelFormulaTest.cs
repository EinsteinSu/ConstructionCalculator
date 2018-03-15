using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class ExcelFormulaTest
    {
        [TestMethod]
        public void AddingFormula()
        {
            using (var excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("New");
                var sheet = excel.Workbook.Worksheets[1];
                sheet.Cells[1, 1].Value = 1;
                sheet.Cells[1, 2].Value = 1;
                sheet.Cells[1, 3].Formula = "SUM(A1:B1)";
                sheet.Cells[1, 3].Calculate();
                Assert.AreEqual("2", sheet.Cells[1, 3].Text);
            }
        }

        [TestMethod]
        public void PowerFormula()
        {
            using (var excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("New");
                var sheet = excel.Workbook.Worksheets[1];
                sheet.Cells[1, 1].Value = 2;
                sheet.Cells[1, 3].Formula = "SUM(A1,2)";
                sheet.Cells[1, 3].Calculate();
                Assert.AreEqual("4", sheet.Cells[1, 3].Text);
            }
        }
    }
}
