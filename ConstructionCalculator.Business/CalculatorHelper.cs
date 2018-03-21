using System.Collections.Generic;
using System.IO;
using System.Linq;
using ConstructionCalculator.Business.Imports;
using ConstructionCalculator.DataAccess;
using OfficeOpenXml;

namespace ConstructionCalculator.Business
{
    //to be tested using interface for mocking
    public class CalculatorHelper
    {
        public void CalcAndExportExcel(string fileName)
        {
            string originalFileName = fileName + ".xlsx";
            string savingFileName = fileName + "_Processed.xlsx";

            var importer = new ConstructionImport(originalFileName);
            importer.Import();

            using (var excel = new ExcelPackage(new FileInfo(originalFileName)))
            {
                using (var context = new ConstructionDataContext())
                {
                    var cellmappings = context.CellMappings.ToList();
                    var sheet = excel.Workbook.Worksheets[1];
                    int row = 1;
                    foreach (var construction in context.Constructions)
                    {

                        SetFormular(context, sheet, row, cellmappings, construction);
                        row++;
                    }
                    sheet.Cells.Calculate();
                    context.Database.ExecuteSqlCommand("Delete from Constructions");
                }
                excel.SaveAs(new FileInfo(savingFileName));
            }
        }

        public static void SetFormular(ConstructionDataContext context, ExcelWorksheet sheet, int row, IList<CellMapping> mappings, Construction construction)
        {
            construction.BusinessValue = FindBusinessValue(context, construction);
            //find the column at the end of the raw data e.g 11, 11 is a constant value
            for (int i = 11; i < mappings.Count + 1; i++)
            {
                var mapping = mappings[i];
                sheet.Cells[row, mapping.ColumnNumber].Formula = ProcessFormula(mapping.Formula, construction);
            }
        }

        //replace the data from parameter table by construction
        private static string ProcessFormula(string formula, Construction construction)
        {
            var businessValue = construction.BusinessValue;
            var constructionValue = construction.ConstructionValue;
            formula = formula.Replace("", "");
            return formula;
        }

        private static BusinessValue FindBusinessValue(ConstructionDataContext context, Construction construction)
        {
            return context.BusinessValues.FirstOrDefault(f => f.Id == construction.BusinessValueId
                                                              && f.FeatureId == construction.BusinessFeatureId);
        }
    }

    public enum CalculatGroup
    {
        潜在风险, 接受水准, 防火水准, 火灾风险
    }
}
