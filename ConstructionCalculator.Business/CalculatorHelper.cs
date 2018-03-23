using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
                ProcessInExcel(excel);
                excel.SaveAs(new FileInfo(savingFileName));
            }
        }

        public static void Calc(Stream stream, Action<ExcelPackage> assertAction)
        {
            var importer = new ConstructionImport(stream);
            importer.Import();

            using (var excel = new ExcelPackage(stream))
            {
                ProcessInExcel(excel);
                assertAction?.Invoke(excel);
            }
        }

        private static void ProcessInExcel(ExcelPackage excel)
        {
            using (var context = new ConstructionDataContext())
            {
                var cellmappings = context.CellMappings.ToList();
                var sheet = excel.Workbook.Worksheets[1];
                int row = 2;//with header
                foreach (var construction in context.Constructions.Include(i => i.BusinessFeature).Include(i => i.ConstructionValue))
                {
                    SetFormular(context, sheet, row, cellmappings, construction);
                    row++;
                }
                sheet.Cells.Calculate();
                context.Database.ExecuteSqlCommand("Delete from Constructions");
            }
        }

        public static void SetFormular(ConstructionDataContext context, ExcelWorksheet sheet, int row, IList<CellMapping> mappings, Construction construction)
        {
            //load business value
            //find the column at the end of the raw data e.g 11, 11 is a constant value
            for (int i = 25; i < mappings.Count; i++)
            {
                var mapping = mappings[i];
                var formula = ParameterReplace(mapping.Formula, construction);
                formula = formula.Replace("{row}", row.ToString());
                sheet.Cells[row, mapping.ColumnNumber].Formula = formula;
            }
        }

        //replace the data from parameter table by construction
        public static string ParameterReplace(string formula, Construction construction)
        {
            //business values
            formula = formula.Replace("GDQI", construction.BusinessFeature.GdQi.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("YDQM", construction.BusinessFeature.YdQm.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("HZMYYZI", construction.BusinessFeature.Hzmyyzi.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("HDYZA", construction.BusinessFeature.Hdyza.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("YLYZD", construction.BusinessFeature.Ylyzd.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("SSSJXZZP", construction.BusinessFeature.Sssjxzzp.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("JZYZ", construction.BusinessFeature.Jzyz.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("RKMDQZ", construction.BusinessFeature.Rkmdqz.ToString(CultureInfo.InvariantCulture));
            //construction values
            formula = formula.Replace("JGKHSJ", construction.ConstructionValue.Jgkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("WQKHSJ", construction.ConstructionValue.Wqkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("WDDDKHSJ", construction.ConstructionValue.Wdkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("NQKHSJ", construction.ConstructionValue.Nqkhsj.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("JZKHYZF", construction.ConstructionValue.Jzkhyz.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("PJKHNLF", construction.ConstructionValue.Pjkhnl.ToString(CultureInfo.InvariantCulture));
            formula = formula.Replace("JGKHYZF0", construction.ConstructionValue.Jgkhyz.ToString(CultureInfo.InvariantCulture));
            return formula;
        }


    }
}
