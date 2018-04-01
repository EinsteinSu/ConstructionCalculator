using System;
using System.Drawing;
using System.IO;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class CalculatorHelperTest : TestBase
    {
        private const string Folder = "D:\\Test";

        [TestCleanup]
        public override void Cleanup()
        {
            base.Cleanup();
            if (Directory.Exists(Folder)) Directory.Delete(Folder, true);
        }

        [TestMethod]
        public void ParameterReplace()
        {
            var construction = new Construction();
            var feature = new BusinessFeature
            {
                GdQi = 1,
                Jzyz = 3
            };
            var constructionValue = new ConstructionValue
            {
                Jzkhyz = 3,
                Pjkhnl = 4
            };
            construction.ConstructionValue = constructionValue;

            construction.BusinessFeature = feature;
            var formula = "GDQI * JZYZ";
            formula = CalculatorHelper.ParameterReplace(formula, construction);
            Assert.AreEqual(formula, "1 * 3");

            formula = "JZKHYZF * PJKHNLF";
            formula = CalculatorHelper.ParameterReplace(formula, construction);
            Assert.AreEqual("3 * 4", formula);
        }

        private void InitializeData()
        {
            ImportCellMappings();
            ImportBusinessValue();
            ImportBusinessFeature();
            ImportConstructionValue();
            ImportRiskLevel();
        }

        [TestMethod]
        public void Calc()
        {
            InitializeData();
            ImportAndValidate("Construction.xlsx", stream =>
            {
                CalculatorHelper.Calc(stream, excel =>
                {
                    //TODO assert the headers and values
                    excel.SaveAs(new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test.xlsx")));
                });
            });
        }

        [TestMethod]
        public void CalcForFolder()
        {
            InitializeData();
            const int itemCount = 10;
            if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
            ImportAndValidate("Construction.xlsx", stream =>
            {
                for (var i = 0; i < itemCount; i++)
                    using (var fileStream = File.Create(Path.Combine(Folder, $"{i}.xlsx")))
                    {
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(fileStream);
                    }
            });
            foreach (var file in Directory.GetFiles(Folder, "*.xlsx"))
            {
                Console.WriteLine($"Processing {Path.GetFileName(file)}");
                CalculatorHelper.CalcAndExportExcel(file);
            }

            var count = 0;
            foreach (var file in Directory.GetFiles(Folder, "*process")) count++;
            Console.WriteLine(count);
        }

        [TestMethod]
        public void GetParemeterT()
        {
            double input = 0.2;
            var result = CalculatorHelper.GetParamerT(input);
            Assert.AreEqual(result, 0.2);
            input = 1.5;
            result = CalculatorHelper.GetParamerT(input);
            Assert.AreEqual(0.5, result);
            input = -0.2;
            CalculatorHelper.GetParamerT(input);
            result = CalculatorHelper.GetParamerT(input);
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void GetRiskLevelColor()
        {
            ImportRiskLevel();
            const double value = 0.64;
            var color = CalculatorHelper.GetRiskLevelColor(value, Context);
            Assert.AreEqual(color, Color.White);
        }

        [TestMethod]
        public void GetRiskLevel()
        {
            ImportRiskLevel();
            const double value = 0.64;
            var item = CalculatorHelper.GetRiskLevel(value, Context);
            Assert.AreEqual(item.Color.ConvertToColor(), Color.White);
        }

        private void ImportCellMappings()
        {
            ImportAndValidate("CellMapping.xlsx", stream =>
            {
                var importer = new CellMappingImport(stream);
                importer.Import();
            });
        }

        private void ImportBusinessValue()
        {
            ImportAndValidate("BusinessValue.xlsx", stream =>
            {
                var importer = new BusinessValueImport(stream);
                importer.Import();
            });
        }

        private void ImportBusinessFeature()
        {
            ImportAndValidate("BusinessFeature.xlsx", stream =>
            {
                var importer = new BusinesFeatureImport(stream);
                importer.Import();
            });
        }

        private void ImportConstructionValue()
        {
            ImportAndValidate("ConstructionValue.xlsx", stream =>
            {
                var importer = new ConstructionValueImport(stream);
                importer.Import();
            });
        }

        private void ImportRiskLevel()
        {
            ImportAndValidate("RiskLevel.xlsx", stream =>
            {
                var importer = new RiskLevelImport(stream);
                importer.Import();
            });
        }
    }
}