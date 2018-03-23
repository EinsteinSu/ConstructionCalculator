using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConstructionCalculator.Business.Test
{
    [TestClass]
    public class CalculatorHelperTest : TestBase
    {
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
            string formula = "GDQI * JZYZ";
            formula = CalculatorHelper.ParameterReplace(formula, construction);
            Assert.AreEqual(formula, "1 * 3");

            formula = "JZKHYZF * PJKHNLF";
            formula = CalculatorHelper.ParameterReplace(formula, construction);
            Assert.AreEqual("3 * 4", formula);
        }

        [TestMethod]
        public void Calc()
        {
            ImportCellMappings();
            ImportBusinessValue();
            ImportBusinessFeature();
            ImportConstructionValue();
            ImportAndValidate("Construction.xlsx", stream => { CalculatorHelper.Calc(stream, excel =>
            {

                //TODO assert the values
                excel.SaveAs(new FileInfo("D:\\test.xlsx"));
            }); });

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
    }
}
